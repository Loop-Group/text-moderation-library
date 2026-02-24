namespace TextModeration;

/// <summary>
/// Opciones de configuración para <see cref="TextModerationService"/>.
/// Contiene información sobre la API, modelo y generación de prompt.
/// </summary>
public class TextModerationOptions
{
    /// <summary>
    /// URL base del endpoint de la API de moderación de texto.
    /// Por defecto apunta a Ollama.
    /// </summary>
    public string BaseUrl { get; } = "https://ollama.com/api/generate";

    /// <summary>
    /// Modelo de IA que se utilizará para la evaluación del texto.
    /// Ejemplo: "gpt-oss:20b".
    /// </summary>
    public string Model { get; } = "gpt-oss:20b";

    /// <summary>
    /// Clave de API requerida para autenticar la petición.
    /// Debe configurarse antes de usar el servicio.
    /// </summary>
    public required string ApiKey { get; set; }

    /// <summary>
    /// Genera el prompt que será enviado a la API de moderación.
    /// El prompt instruye al modelo a clasificar el texto en una sola categoría.
    /// </summary>
    /// <param name="text">Texto que se desea analizar/moderar.</param>
    /// <returns>Prompt formateado listo para enviar a la API.</returns>
    public string GetPromp(string text)
    {
        return $"""
               You are a strict content moderation system.

               Your task is to classify the text into ONE of these categories ONLY:

               - Appropriate → Safe, polite, neutral, normal conversation.
               - Inappropriate → Insults, hate speech, sexual content, threats, harassment, illegal content, discrimination, or clearly offensive language.
               - Unknown → The text is unclear, too short, ambiguous, nonsensical, or not enough context to judge.
               - Error → The input is empty, corrupted, unreadable, or not valid text.

               IMPORTANT RULES:
               - Respond with ONLY ONE WORD from the list above.
               - Do NOT explain.
               - Do NOT add punctuation.
               - Do NOT add extra text.
               - If unsure, choose Unknown.

               Text to analyze:
               "{text}"
               """;
    }
}