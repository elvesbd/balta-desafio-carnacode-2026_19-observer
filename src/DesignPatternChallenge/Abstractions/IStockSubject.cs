using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.Abstractions;

public interface IStockSubject
{
    void NotifyObservers();
    void Subscribe(IStockObserver observer);
    void Unsubscribe(IStockObserver observer);
}