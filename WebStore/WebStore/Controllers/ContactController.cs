using Microsoft.AspNetCore.Mvc;

namespace WebStore.Controllers
{
    [Route("")]
    public class ContactController : Controller
    {
        /// <summary>
        /// Contacts
        /// </summary>
        /// <returns></returns>
        [Route("contacts")]
        public IActionResult Contacts()
        {
            return View();
        }
    }
}