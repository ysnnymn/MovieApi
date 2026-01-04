using Microsoft.AspNetCore.Mvc;

namespace MovieApi.WebUI.ViewComponents.AdminLayoutViewComponent;

public class _AdminLayoutScriptsComponentPArtial:ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
    
}