using HtmlAgilityPack;

var url = "https://www.basketball-reference.com/boxscores/";
HtmlWeb web = new HtmlWeb();
HtmlDocument doc = web.Load(url);

var tableNodeGameSummary = doc.DocumentNode.SelectSingleNode(
    "//*[@id=\"content\"]/div/div/table[2]"
);

var tableNodeConfStandingsEast = doc.DocumentNode.SelectSingleNode(
    "//*[@id=\"confs_standings_E\"]"
);

var tableNodeConfStandingsWest = doc.DocumentNode.SelectSingleNode(
    "//*[@id=\"confs_standings_W\"]"
);

Console.WriteLine(tableNodeGameSummary.InnerText);
Console.WriteLine(tableNodeConfStandingsEast.InnerText);
Console.WriteLine(tableNodeConfStandingsWest.InnerText);

Console.ReadKey();
