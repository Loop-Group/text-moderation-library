namespace TextModeration;

/// <summary>
/// Clase estática que contiene una lista de palabras prohibidas para moderación de texto.
/// Esta lista se utiliza en <see cref="TextModerationService"/> para detección rápida de contenido inapropiado.
/// </summary>
public static class BlackList
{
    /// <summary>
    /// Obtiene un arreglo con todas las palabras prohibidas.
    /// </summary>
    /// <returns>Un <see cref="string[]"/> con palabras inapropiadas, insultos, contenido sexual, violencia, racismo y spam.</returns>
    /// <remarks>
    /// La lista incluye varias categorías:
    /// <list type="bullet">
    ///   <item><description>Insultos básicos en español e inglés.</description></item>
    ///   <item><description>Palabras sexuales y relacionadas con contenido adulto.</description></item>
    ///   <item><description>Violencia, amenazas y homicidio.</description></item>
    ///   <item><description>Racismo, discriminación y términos ofensivos.</description></item>
    ///   <item><description>Spam, enlaces sospechosos y mensajes promocionales.</description></item>
    /// </list>
    /// </remarks>
    public static string[] GetWords()
    {
        return new string[]
        {
            // Insultos básicos
            "idiota", "estúpido", "tonto", "imbécil", "pendejo", "gilipollas", "bastardo", "mierda", "culero", "cabrón",
            "zoquete", "tarado", "baboso", "bruto", "cretino", "malnacido", "ganso", "bobo", "payaso", "imbecil",
            "asshole", "bastard", "jerk", "moron", "dumb", "idiot", "loser", "fool", "scumbag", "nitwit",

            // Palabras sexuales
            "puta", "prostituta", "coño", "verga", "pene", "vagina", "sexo", "follar", "porn", "porno","pinga",
            "cabrón sexual", "masturbación", "fuck", "shit", "cock", "dick", "bitch", "slut", "whore", "ass",
            "nalgas", "tetas", "clítoris", "vulva", "penis", "sex", "fucking", "cum", "orgasm", "sperm",

            // Violencia y amenazas
            "violencia", "muerte", "asesinar", "matar", "golpear", "atacar", "explosión", "bomb", "shoot", "kill",
            "asesino", "homicidio", "asesinato", "massacre", "terror", "tortura", "sangre", "arma", "gun", "knife",
            "stab", "shooting", "explode", "terrorist", "slaughter", "burn", "burned", "lynch", "hang", "shoots",

            // Racismo y discriminación
            "racista", "negro", "blanco", "judio", "musulmán", "homo", "gay", "maricón", "nazi", "facha",
            "cholo", "mulato", "mongolo", "indio", "oriental", "esclavo", "racism", "nigger", "fag", "slut",
            "retard", "cracker", "kike", "chink", "gook", "spic", "paki", "towelhead", "coon", "wetback",

            // Spam y enlaces sospechosos
            "http", "https", ".com", ".net", "ganar dinero", "bitcoin", "crypto", "free money",
            "click here", "subscribe", "follow me", "earn cash", "limited offer", "winner", "prize", "lottery",
            "free gift", "buy now", "money back", "discount", "cheap", "sale", "get rich", "credit card", "loan", "investment",
            "work from home", "earn online", "casino", "gambling", "adult site", "clickbait", "ads", "promo", "deal", "bonus"
        };
    }
}
