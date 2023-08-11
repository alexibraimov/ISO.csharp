namespace ExampleWebApplication.Pages
{
    using ISOLib;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.Logging;

    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public Countries Countries { get; }
        public IndexModel(ILogger<IndexModel> logger, Countries countryService)
        {
            _logger = logger;
            Countries = countryService;
        }
    }
}