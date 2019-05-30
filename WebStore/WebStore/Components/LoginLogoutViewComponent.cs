using Microsoft.AspNetCore.Mvc;

namespace WebStore.Components
{
    public class LoginLogoutViewComponent : ViewComponent
    {
        /// <summary>
        /// Invoke component
        /// </summary>
        /// <returns></returns>
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
