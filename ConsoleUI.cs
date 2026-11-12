using System;

namespace GuessTheNumber
{
    public class ConsoleUI : IObserver
    {
        public string AskDifficulty()
        {
            Console.WriteLine("\nВыберите сложность:");
            Console.WriteLine("1. Легкая (1-10, 5 попыток)");
            Console.WriteLine("2. Средняя (1-100, 7 попыток)");
            Console.WriteLine("3. Сложная (1-1000, 10 попыток)");
            Console.Write("Ваш выбор (1/2/3): ");
            return Console.ReadLine() ?? "1";
        }

        public int GetGuess()
        {
            while (true)
            {
                Console.Write("Введите ваше число: ");
                if (int.TryParse(Console.ReadLine(), out int guess))
                {
                    return guess;
                }
                Console.WriteLine("Ошибка! Введите целое число.");
            }
        }

        public void Update(string eventType, int guess, int attempts)
        {
            switch (eventType)
            {
                case "more": Console.WriteLine($"Больше! (Попытка {attempts})"); break;
                case "less": Console.WriteLine($"Меньше! (Попытка {attempts})"); break;
                case "win": Console.WriteLine($"🎉 Победа! Вы угадали с {attempts} попытки."); break;
                case "lose": Console.WriteLine($"😢 Вы проиграли. Попытки закончились."); break;
            }
        }
    }
}
