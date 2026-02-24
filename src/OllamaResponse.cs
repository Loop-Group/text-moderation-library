using System.Text.Json.Serialization;

/// <summary>
/// Representa la respuesta devuelta por la API de moderación de texto (Ollama).
/// Contiene la clasificación del texto y metadatos opcionales.
/// </summary>
public class OllamaResponse
{
    /// <summary>
    /// La clasificación del texto devuelta por la IA.
    /// Valores típicos: "Inappropriate", "Appropriate", "Unknown", "Error".
    /// Esta propiedad se mapea desde la propiedad JSON <c>response</c>.
    /// </summary>
    [JsonPropertyName("response")]
    public string Response { get; set; } = string.Empty;
}