namespace AK8PO_snake;

public class GameSettings
{
    public int Width { get; }
    public int Height { get; }
    public int InitialScore { get; }
    public int Speed { get; }

    public GameSettings()
    {
        InitialScore = Constants.InitialScore;
        Speed = Constants.Speed;
        Width = Constants.Width;
        Height = Constants.Height;
        Console.SetWindowSize(Width, Height);
    }

    public void Restore()
    {
        Console.SetWindowSize(Width, Height);
    }
}