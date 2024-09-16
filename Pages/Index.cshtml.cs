using CS058_ASP.NET_Razor_09.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CS058_ASP.NET_Razor_09.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly MyBlogContext _blogContext;

        public IndexModel(ILogger<IndexModel> logger, MyBlogContext myContext)
        {
            _logger = logger;
            _blogContext = myContext;
        }

        public void OnGet()
        {
            var posts = (from a  in _blogContext.articles
                        orderby a.Created descending
                        select a).ToList();
            ViewData["posts"]= posts;
        }
    }
}
