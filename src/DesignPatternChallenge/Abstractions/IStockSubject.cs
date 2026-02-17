using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.Abstractions;

public interface IStockSubject
{
    void NotifyObservers();
    void Subscribe(StockPriceChange priceChange);
    void Unsubscribe(StockPriceChange priceChange);
}