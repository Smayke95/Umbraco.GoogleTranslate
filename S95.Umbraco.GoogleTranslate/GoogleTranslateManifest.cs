using System.Collections.Generic;
using Umbraco.Cms.Core.Manifest;

namespace S95.Umbraco.GoogleTranslate;

public class GoogleTranslateManifest : IManifestFilter
{
    public void Filter(List<PackageManifest> manifests)
    {
        manifests.Add(new PackageManifest
        {
            PackageName = "Umbraco Google Translate",
            Version = "1.0.3",
            Stylesheets = new[]
            {
                "/App_Plugins/S95.Umbraco.GoogleTranslate/Css/googleTranslateStyle.css"
            },
            Scripts = new[]
            {
                "/App_Plugins/S95.Umbraco.GoogleTranslate/Scripts/googleTranslate.service.js",
                "/App_Plugins/S95.Umbraco.GoogleTranslate/Scripts/googleTranslateButton.component.js",
                "/App_Plugins/S95.Umbraco.GoogleTranslate/Scripts/googleTranslateButton.decorator.js",
                "/App_Plugins/S95.Umbraco.GoogleTranslate/Scripts/googleTranslateEditor.controller.js"
            }
        });
    }
}