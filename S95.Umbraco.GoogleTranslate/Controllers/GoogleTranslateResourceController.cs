using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System.Linq;

namespace S95.Umbraco.GoogleTranslate.Controllers;

public class GoogleTranslateResourceController : Controller
{
    public IActionResult Index(string folder, string file)
    {
        var assembly = typeof(GoogleTranslateResourceController).Assembly;

        var manifestResourceName = assembly
            .GetManifestResourceNames()
            .FirstOrDefault(x => x.Contains(folder.Replace("/", ".") + "." + file));

        if (manifestResourceName is not null)
        {
            var resourceStream = assembly.GetManifestResourceStream(manifestResourceName);

            if (resourceStream is not null)
            {
                new FileExtensionContentTypeProvider().TryGetContentType(manifestResourceName, out string? contentType);
                return new FileStreamResult(resourceStream, contentType ?? "text/plain");
            }
        }

        return NotFound();
    }
}