namespace TextModeration;

/// <summary>
/// Define la interfaz para un servicio de moderación de texto.
/// Permite analizar texto para determinar si es apropiado, inapropiado o desconocido.
/// </summary>
public interface ITextModerationService
{
    /// <summary>
    /// Analiza un texto para determinar si es apropiado o inapropiado.
    /// </summary>
    /// <param name="text">El texto que se desea analizar.</param>
    /// <param name="ct">Token de cancelación opcional.</param>
    /// <returns>
    /// Un <see cref="TextModerationStatus"/> indicando si el texto es inapropiado, apropiado o desconocido.
    /// </returns>
    /// <remarks>
    /// Este método realiza primero validaciones básicas locales:
    /// <list type="bullet">
    ///   <item>
    ///     <description>Verifica si el texto contiene palabras de la lista negra (<see cref="BlackList.GetWords"/>).</description>
    ///   </item>
    ///   <item>
    ///     <description>Verifica si hay caracteres repetidos consecutivamente más de 5 veces usando expresiones regulares.</description>
    ///   </item>
    /// </list>
    /// Si pasa estas validaciones, delega el análisis a la IA mediante <see cref="AnalyzeWithAIAsync"/>.
    /// </remarks>
    Task<TextModerationStatus> AnalyzeAsync(string text , CancellationToken ct = default);
}
