using Microsoft.AspNetCore.Mvc;

namespace WebStore.Controllers
{
    [Route("")]
    public class BlogController : Controller
    {
        /// <summary>
        /// Blog list
        /// </summary>
        /// <returns></returns>
        [Route("blog_list")]
        public IActionResult BlogList()
        {
            return View();
        }

        /// <summary>
        /// Blog single
        /// </summary>
        /// <returns></returns>
        [Route("blog_single")]
        public IActionResult BlogSingle()
        {
            return View();
        }
    }
}