using HtmlAgilityPack;
using Sports_Results_Notifier.Models;

namespace Sports_Results_Notifier.Services;

public class ScraperService : IScraperService
{
    public HtmlDocument ScrapeHtml(string html)
    {
        var url = "https://www.basketball-reference.com/boxscores/";
        var web = new HtmlWeb();
        var doc = web.Load(url);

        return doc;
    }

    public Game GetGamePlayedInfo(HtmlDocument doc)
    {
        var game = new Game();

        game.Date = DateOnly.Parse(
            doc.DocumentNode.SelectSingleNode("//span[@class='button2 index']").InnerText
        );

        game.WinningTeam = doc
            .DocumentNode.SelectSingleNode(".//tr[@class='winner']/td[1]")
            .InnerText;

        game.LosingTeam = doc
            .DocumentNode.SelectSingleNode(".//tr[@class='loser']/td[1]")
            .InnerText;

        var winnerScoreStr = doc
            .DocumentNode.SelectSingleNode(".//tr[@class='winner']/td[2]")
            .InnerText;
        int winnerScore;
        if (int.TryParse(winnerScoreStr, out winnerScore))
            game.WinnerScore = winnerScore;

        var loserScoreStr = doc
            .DocumentNode.SelectSingleNode(".//tr[@class='loser']/td[2]")
            .InnerText;
        int loserScore;
        if (int.TryParse(loserScoreStr, out loserScore))
            game.LoserScore = loserScore;

        EmailService.SendEmail(game);
        return game;
    }
}
