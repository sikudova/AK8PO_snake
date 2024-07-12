namespace AK8PO_snake;

public class Berry
{
    private readonly GameSettings _gameSettings;
    private Pixel Position { get; set; }

    public Berry(GameSettings gameSettings)
    {
        _gameSettings = gameSettings;
        Move();
    }

    public void Draw()
    {
        Position.Draw();
    }

    public bool IsEaten(Pixel head)
    {
        return Position.X == head.X && Position.Y == head.Y;
    }

    public void Move()
    {
        Position = Pixel.GeneratePixel(Constants.BerryColor, _gameSettings.Width - 1, _gameSettings.Height - 1);
    }
}