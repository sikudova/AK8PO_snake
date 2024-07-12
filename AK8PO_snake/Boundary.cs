namespace AK8PO_snake;

public static class Boundary
{
    public static void Draw(int width, int height)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(width);

        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(height);

        for (int i = 0; i < width; i++)
        {
            new Pixel(i, 0, Constants.BoundaryColor).Draw();
            new Pixel(i, height - 1, Constants.BoundaryColor).Draw();
        }

        for (int i = 0; i < height; i++)
        {
            new Pixel(0, i, Constants.BoundaryColor).Draw();
            new Pixel(width - 1, i, Constants.BoundaryColor).Draw();
        }
    }
}