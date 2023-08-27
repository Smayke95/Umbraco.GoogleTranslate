using Microsoft.AspNetCore.Mvc;
using S95.Umbraco.GoogleTranslate.Interfaces;
using S95.Umbraco.GoogleTranslate.Models;
using System.Threading.Tasks;
using Umbraco.Cms.Web.BackOffice.Controllers;

namespace S95.Umbraco.GoogleTranslate.Controllers;

public class GoogleTranslateController : UmbracoAuthorizedApiController
{
    private readonly IGoogleTranslateService _googleTranslateService;

    public GoogleTranslateController(IGoogleTranslateService googleTranslateService)
    {
        _googleTranslateService = googleTranslateService;
    }

    [HttpPost]
    public async Task<string> Translate([FromBody] TranslateRequest request)
        => await _googleTranslateService.Translate(request);
}