using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using S95.Umbraco.GoogleTranslate.Controllers;
using S95.Umbraco.GoogleTranslate.Interfaces;
using S95.Umbraco.GoogleTranslate.Models;
using S95.Umbraco.GoogleTranslate.Services;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Web.Common.ApplicationBuilder;

namespace S95.Umbraco.GoogleTranslate.Composers;

public class GoogleTranslateComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.Services.Configure<UmbracoPipelineOptions>(options =>
        {
            options.AddFilter(new UmbracoPipelineFilter(nameof(GoogleTranslateResourceController))
            {
                Endpoints = app => app.UseEndpoints(endpoints =>
                {
                    endpoints.MapControllerRoute(
                        "GoogleTranslate Resource Controller",
                        "/App_Plugins/S95.Umbraco.GoogleTranslate/{folder}/{file}",
                        new { Controller = "GoogleTranslateResource", Action = "Index" }
                    );
                })
            });
        });

        builder.ManifestFilters().Append<GoogleTranslateManifest>();

        builder.Services.Configure<Configuration>(builder.Config.GetSection("GoogleTranslate"));
        builder.Services.AddTransient<IGoogleTranslateService, GoogleTranslateService>();
    }
}