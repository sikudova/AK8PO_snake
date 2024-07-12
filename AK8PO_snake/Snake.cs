namespace AK8PO_snake;

public class Snake(int score, GameSettings gameSettings)
{
    internal Pixel Head { get; } = new Pixel(gameSettings.Width / 2, gameSettings.Height / 2, Constants.SnakeHeadColor);
    private readonly List<Pixel> _body = [];
    private Direction _direction = Direction.Right;

    public void Draw()
    {
        DrawHead();
        DrawBody();
    }

    private void DrawHead()
    {
        Head.Draw();
    }

    private void DrawBody()
    {
        foreach (Pixel each in _body)
        {
            each.Draw();
        }
    }

    public void UpdatePosition()
    {
        _body.Add(new Pixel(Head.X, Head.Y, Constants.SnakeColor));
        MoveHead();

        if (_body.Count > score)
        {
            _body.RemoveAt(0);
        }
    }

    public void IncreaseScore()
    {
        score++;
    }

    private void MoveHead()
    {
        switch (_direction)
        {
            case Direction.Up:
                Head.Y--;
                break;
            case Direction.Down:
                Head.Y++;
                break;
            case Direction.Left:
                Head.X--;
                break;
            case Direction.Right:
                Head.X++;
                break;
        }
    }

    public bool IsOverBoundary()
    {
        bool touchedLeftBoundary = Head.X == 0;
        bool touchedRightBoundary = Head.X == gameSettings.Width - 1;
        bool touchedTopBoundary = Head.Y == 0;
        bool touchedBottomBoundary = Head.Y == gameSettings.Height - 1;

        return touchedLeftBoundary || touchedRightBoundary || touchedTopBoundary || touchedBottomBoundary;
    }

    public bool HasEatenItself()
    {
        return _body.Any(part => part.X == Head.X && part.Y == Head.Y);
    }

    private bool IsColliding()
    {
        return IsOverBoundary() || HasEatenItself();
    }

    public void ChangeDirection()
    {
        if (!Console.KeyAvailable) return;
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
        switch (keyInfo.Key)
        {
            case ConsoleKey.LeftArrow:
                if (_direction != Direction.Right)
                {
                    _direction = Direction.Left;
                }

                break;
            case ConsoleKey.RightArrow:
                if (_direction != Direction.Left)
                {
                    _direction = Direction.Right;
                }

                break;
            case ConsoleKey.UpArrow:
                if (_direction != Direction.Down)
                {
                    _direction = Direction.Up;
                }

                break;
            case ConsoleKey.DownArrow:
                if (_direction != Direction.Up)
                {
                    _direction = Direction.Down;
                }

                break;
        }
    }
}