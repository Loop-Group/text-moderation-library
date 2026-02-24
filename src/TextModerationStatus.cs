namespace TextModeration.src;

/// <summary>
/// Representa el estado de moderación de un texto.
/// </summary>
public enum TextModerationStatus
{
    /// <summary>
    /// El texto es seguro, educado, neutral o corresponde a una conversación normal.
    /// </summary>
    Appropriate,

    /// <summary>
    /// El texto contiene insultos, lenguaje ofensivo, contenido sexual, amenazas,
    /// acoso, discriminación o ilegalidades.
    /// </summary>
    Inappropriate,

    /// <summary>
    /// El texto es ambiguo, demasiado corto, confuso o no tiene suficiente contexto para juzgarlo.
    /// </summary>
    Unknown,

    /// <summary>
    /// Hubo un error al analizar el texto, o el texto está vacío, corrupto o no es válido.
    /// </summary>
    Error
}