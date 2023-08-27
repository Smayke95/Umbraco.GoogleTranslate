using Google.Cloud.Translation.V2;
using Microsoft.Extensions.Options;
using S95.Umbraco.GoogleTranslate.Interfaces;
using S95.Umbraco.GoogleTranslate.Models;
using System.Threading.Tasks;

namespace S95.Umbraco.GoogleTranslate.Services;

public class GoogleTranslateService : IGoogleTranslateService
{
    private readonly Configuration _googleTranslateSettings;

    public GoogleTranslateService(IOptions<Configuration> googleTranslateOptions)
    {
        _googleTranslateSettings = googleTranslateOptions.Value;
    }

    public async Task<string> Translate(TranslateRequest request)
    {
        var client = TranslationClient.CreateFromApiKey(_googleTranslateSettings.ApiKey);

        var response = await client.TranslateTextAsync(request.Text, request.TargetLanguage, request.SourceLanguage);

        return response.TranslatedText;
    }
}