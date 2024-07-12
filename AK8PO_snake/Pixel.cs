namespace AK8PO_snake;

public class Pixel(int x, int y, ConsoleColor color)
{
    public int X { get; set; } = x;
    public int Y { get; set; } = y;
    private ConsoleColor Color { get; } = color;

    public void Draw()
    {
        Console.SetCursorPosition(X, Y);
        Console.ForegroundColor = Color;
        Console.Write("■");
    }

    public static Pixel GeneratePixel(ConsoleColor color, int width, int height)
    {
        Random random = new Random();
        return new Pixel(random.Next(width), random.Next(height), color);
    }
}