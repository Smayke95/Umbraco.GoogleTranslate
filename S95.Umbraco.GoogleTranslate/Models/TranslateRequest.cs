namespace S95.Umbraco.GoogleTranslate.Models;

public class TranslateRequest
{
    public string Text { get; set; } = string.Empty;

    public string? SourceLanguage { get; set; }

    public string TargetLanguage { get; set; } = string.Empty;
}