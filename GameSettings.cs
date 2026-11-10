namespace GuessTheNumber
{
    public interface IGameSettings
    {
        int MinNumber { get; }
        int MaxNumber { get; }
        int MaxAttempts { get; }
    }

    public class EasySettings : IGameSettings
    {
        public int MinNumber => 1;
        public int MaxNumber => 10;
        public int MaxAttempts => 5;
    }

    public class MediumSettings : IGameSettings
    {
        public int MinNumber => 1;
        public int MaxNumber => 100;
        public int MaxAttempts => 7;
    }

    public class HardSettings : IGameSettings
    {
        public int MinNumber => 1;
        public int MaxNumber => 1000;
        public int MaxAttempts => 10;
    }
}
