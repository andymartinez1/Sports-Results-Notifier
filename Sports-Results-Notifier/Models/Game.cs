namespace Sports_Results_Notifier.Models;

public class Game
{
    public DateOnly Date { get; set; }

    public string WinningTeam { get; set; } = String.Empty;

    public string LosingTeam { get; set; } = String.Empty;

    public int WinnerScore { get; set; }

    public int LoserScore { get; set; }
}
