using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace TextModeration.src;


/// <summary>
/// Servicio para moderación de texto.
/// Implementa <see cref="ITextModerationService"/> y permite analizar texto localmente
/// mediante reglas básicas y también usando un modelo de IA externo.
/// </summary>
public class TextModerationService : ITextModerationService
{
    private readonly HttpClient _httpClient;
    private readonly TextModerationOptions _options;


    /// <summary>
    /// Inicializa una nueva instancia de <see cref="TextModerationService"/>.
    /// </summary>
    /// <param name="httpClient">Instancia de <see cref="HttpClient"/> usada para hacer llamadas a la API de moderación.</param>
    /// <param name="options">Opciones de configuración del servicio, incluyendo la clave de API y modelo de IA.</param>
    public TextModerationService(HttpClient httpClient, TextModerationOptions options)
    {
        _httpClient = httpClient;
        _options = options;
    }


    /// <inheritdoc/>
    public async Task<TextModerationStatus> AnalyzeAsync(string text, CancellationToken ct = default)
    {
        if(BlackList.GetWords().Any(word => text.Contains(word, StringComparison.OrdinalIgnoreCase)))
            return TextModerationStatus.Inappropriate;

        if (Regex.IsMatch(text, @"(.)\1{5,}")) 
            return TextModerationStatus.Inappropriate;

        return await AnalyzeWithAIAsync(text, ct);
    }


    /// <summary>
    /// Analiza un texto usando la IA para determinar si es apropiado, inapropiado o desconocido.
    /// </summary>
    /// <param name="text">El texto que se desea analizar.</param>
    /// <param name="ct">Token de cancelación opcional.</param>
    /// <returns>
    /// Un <see cref="TextModerationStatus"/> indicando si el texto es apropiado, inapropiado, desconocido o si hubo un error.
    /// </returns>
    /// <remarks>
    /// Este método envía el texto a un modelo de IA especificado en <see cref="TextModerationOptions.Model"/> 
    /// usando la clave de API en <see cref="TextModerationOptions.ApiKey"/> y la URL base en <see cref="TextModerationOptions.BaseUrl"/>.
    /// Se agregan logs de consola para debuguear el flujo completo.
    /// </remarks>
    public async Task<TextModerationStatus> AnalyzeWithAIAsync(string text, CancellationToken ct = default)
    {
        try
        {
            using var timeoutCts = new CancellationTokenSource(TimeSpan.FromSeconds(_options.TimeOut));
            using var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(ct, timeoutCts.Token);

            _httpClient.DefaultRequestHeaders.Remove("Authorization");
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_options.ApiKey}");

            var body = new
            {
                model = _options.Model,
                prompt = _options.GetPromp(text),
                stream = false
            };

            var json = JsonSerializer.Serialize(body);
            using var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_options.BaseUrl, content, linkedCts.Token);

            if (!response.IsSuccessStatusCode)
                return TextModerationStatus.Error;

            var jsonResponse = await response.Content.ReadAsStringAsync(linkedCts.Token);

            var data = JsonSerializer.Deserialize<OllamaResponse>(jsonResponse);

            var result = data?.Response ?? "";

            if (result.Contains("Inappropriate", StringComparison.OrdinalIgnoreCase))
                return TextModerationStatus.Inappropriate;

            if (result.Contains("Appropriate", StringComparison.OrdinalIgnoreCase))
                return TextModerationStatus.Appropriate;

            if (result.Contains("Unknown", StringComparison.OrdinalIgnoreCase))
                return TextModerationStatus.Unknown;

            return TextModerationStatus.Error;
        }
        catch 
        {
            return TextModerationStatus.Error;
        }
    }
}