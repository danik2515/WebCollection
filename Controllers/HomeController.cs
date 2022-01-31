using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebCollection.Models.Interface;
using WebCollection.Models;
using WebCollection.Models.ViewModels;
namespace WebCollection.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        private readonly ICollection _collection;
        private readonly ITheme _theme;
        public HomeController(ILogger<HomeController> logger, ICollection collection, ITheme theme) {
            _logger = logger;
            _collection = collection;
            _theme = theme;
        }

        public IActionResult Index() {
            return View(new CollectionIndexViewModel{Collections=_collection.Collections,ITheme=_theme});
        }

        public IActionResult Privacy() {
            return View();
        }
        
            [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl) {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );
            return LocalRedirect(returnUrl);
        }
            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}