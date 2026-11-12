using System;

namespace GuessTheNumber
{
    public class Game
    {
        private readonly IGameSettings _settings;
        private readonly EventManager _eventManager;
        private int _targetNumber;
        
        public int Attempts { get; private set; }
        public bool IsWon { get; private set; }

        public Game(IGameSettings settings, EventManager eventManager)
        {
            _settings = settings;
            _eventManager = eventManager;
        }

        public void StartNewGame()
        {
            _targetNumber = new Random().Next(_settings.MinNumber, _settings.MaxNumber + 1);
            Attempts = 0;
            IsWon = false;
        }

        public string MakeGuess(int guess)
        {
            Attempts++;

            if (guess == _targetNumber)
            {
                IsWon = true;
                _eventManager.Notify("win", guess, Attempts);
                return "win";
            }

            if (Attempts >= _settings.MaxAttempts)
            {
                _eventManager.Notify("lose", guess, Attempts);
                return "lose";
            }

            if (guess < _targetNumber)
            {
                _eventManager.Notify("more", guess, Attempts);
                return "more";
            }
            else
            {
                _eventManager.Notify("less", guess, Attempts);
                return "less";
            }
        }
    }
}
