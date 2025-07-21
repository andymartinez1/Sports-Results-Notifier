using Sports_Results_Notifier.Services;
using Sports_Results_Notifier.Views;

namespace Sports_Results_Notifier.Controllers;

public class ScraperController
{
    private readonly IScraperService _service;

    public ScraperController(IScraperService service)
    {
        _service = service;
    }

    public void GetGameInfo()
    {
        var url = "https://www.basketball-reference.com/boxscores/";

        var doc = _service.ScrapeHtml(url);

        var game = _service.GetGamePlayedInfo(doc);

        UserInterface.ViewTable(game);
    }
}
