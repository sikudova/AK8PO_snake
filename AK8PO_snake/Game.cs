using System.Diagnostics;

namespace AK8PO_snake;

public class Game
{
    private readonly GameSettings _gameSettings = new GameSettings();
    private readonly Snake _snake;
    private readonly Berry _berry;
    private readonly int _initialScore;
    private readonly int _speed;

    public Game()
    {
        _snake = new Snake(_initialScore, _gameSettings);
        _berry = new Berry(_gameSettings);
        _initialScore = _gameSettings.InitialScore;
        _speed = _gameSettings.Speed;
    }

    public void Run()
    {
        var score = _initialScore;
        var gameOver = false;

        while (!gameOver)
        {
            Console.Clear();

            _snake.UpdatePosition();
            gameOver = _snake.IsOverBoundary() || _snake.HasEatenItself();

            Boundary.Draw(_gameSettings.Width, _gameSettings.Height);

            if (_berry.IsEaten(_snake.Head))
            {
                score++;
                _berry.Move();
                _snake.IncreaseScore();
            }

            _snake.Draw();
            _berry.Draw();
            HandleGameSpeed();
        }

        EndGame(score);
    }

    private void HandleGameSpeed()
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        while (stopwatch.ElapsedMilliseconds <= _speed)
        {
            _snake.ChangeDirection();
        }
    }

    private void EndGame(int score)
    {
        Console.WriteLine("Your final score: " + score);
        _gameSettings.Restore();
    }
}