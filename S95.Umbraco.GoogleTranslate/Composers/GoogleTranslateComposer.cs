using Microsoft.Extensions.DependencyInjection;
using S95.Umbraco.GoogleTranslate.Interfaces;
using S95.Umbraco.GoogleTranslate.Models;
using S95.Umbraco.GoogleTranslate.Services;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace S95.Umbraco.GoogleTranslate.Composers;

public class GoogleTranslateComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.Services.Configure<Configuration>(builder.Config.GetSection("GoogleTranslate"));
        builder.Services.AddTransient<IGoogleTranslateService, GoogleTranslateService>();
    }
}