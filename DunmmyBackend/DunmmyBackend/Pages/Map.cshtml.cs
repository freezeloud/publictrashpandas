using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DunmmyBackend.Pages
{
    public class MapModel : PageModel
    {
        public IDataProvider DataProvider;

        public MapModel(IDataProvider dataProvider)
        {
            DataProvider = dataProvider;
        }

        public void OnGet()
        {
        }
    }
}
