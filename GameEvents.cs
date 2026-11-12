using System.Collections.Generic;

namespace GuessTheNumber
{
    public interface IObserver
    {
        void Update(string eventType, int guess, int attempts);
    }

    public class EventManager
    {
        private readonly List<IObserver> _observers = new List<IObserver>();

        public void Subscribe(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Notify(string eventType, int guess, int attempts)
        {
            foreach (var observer in _observers)
            {
                observer.Update(eventType, guess, attempts);
            }
        }
    }
}
