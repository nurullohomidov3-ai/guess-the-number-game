using System;

namespace GuessTheNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EventManager eventManager = new EventManager();
            ConsoleUI ui = new ConsoleUI();
            FileStorage storage = new FileStorage();
            eventManager.Subscribe(ui);

            Console.WriteLine($"Сыграно игр ранее: {storage.GetAllStats().Count}");

            string choice = ui.AskDifficulty();
            IGameSettings settings;
            string diffName;

            switch (choice)
            {
                case "1": settings = new EasySettings(); diffName = "Легкая"; break;
                case "2": settings = new MediumSettings(); diffName = "Средняя"; break;
                default: settings = new HardSettings(); diffName = "Сложная"; break;
            }

            Game game = new Game(settings, eventManager);
            game.StartNewGame();
            Console.WriteLine($"Я загадал число от {settings.MinNumber} до {settings.MaxNumber}. У вас {settings.MaxAttempts} попыток.");

            while (true)
            {
                int guess = ui.GetGuess();
                string result = game.MakeGuess(guess);
                if (result == "win" || result == "lose")
                {
                    storage.SaveResult(new GameResult {
                        Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        Difficulty = diffName,
                        Attempts = game.Attempts,
                        Result = result == "win" ? "Победа" : "Поражение"
                    });
                    Console.WriteLine("\n=== СТАТИСТИКА ===");
                    foreach (var s in storage.GetAllStats())
                        Console.WriteLine($"{s.Date} | {s.Difficulty} | {s.Attempts} | {s.Result}");
                    break;
                }
            }
            Console.ReadKey();
        }
    }
}
