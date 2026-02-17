using DesignPatternChallenge.Models;

namespace DesignPatternChallenge.Abstractions;

public interface IStockObserver
{
    void Update(StockPriceChange priceChange);
}