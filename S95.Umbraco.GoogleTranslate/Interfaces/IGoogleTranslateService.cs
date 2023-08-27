using S95.Umbraco.GoogleTranslate.Models;
using System.Threading.Tasks;

namespace S95.Umbraco.GoogleTranslate.Interfaces;

public interface IGoogleTranslateService
{
    Task<string> Translate(TranslateRequest request);
}