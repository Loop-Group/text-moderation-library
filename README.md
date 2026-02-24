# TextModeration

`Loop.TextModeration` es una librería ligera de C# para moderación de texto, que combina **validaciones locales** con **análisis de IA** usando proveedores como Ollama.
Detecta insultos, contenido sexual, violencia, discriminación, spam y patrones de texto sospechosos.

---

## Características

- Validación de palabras prohibidas (lista negra).
- Detección de caracteres repetidos excesivos.
- Integración con modelos de IA para análisis avanzado.
- Retorno de estados de moderación: `Appropriate`, `Inappropriate`, `Unknown` o `Error`.
- Compatible con .NET 6/7/8/9.
- Documentación XML incluida para Visual Studio y generación de docs.

---

## Instalación

```bash
dotnet add package Loop.TextModeration
