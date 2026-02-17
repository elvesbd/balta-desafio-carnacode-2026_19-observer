using DesignPatternChallenge.Models;
using DesignPatternChallenge.Abstractions;

namespace DesignPatternChallenge.Subjects;

public class Stock(string symbol, decimal initialPrice) : IStockSubject
{
    private StockPriceChange? _lastChange;
    private readonly List<IStockObserver> _observers = [];

    public string Symbol { get; set; } = symbol;
    public decimal Price { get; set; } = initialPrice;
    
    public void NotifyObservers()
    {
        if (_lastChange is null) return;

        foreach (var observer in _observers)
            observer.Update(_lastChange);
    }

    public void Subscribe(IStockObserver observer)
    {
        _observers.Add(observer);
        Console.WriteLine($"[{Symbol}] Novo observador inscrito ({_observers.Count} total)");
    }

    public void Unsubscribe(IStockObserver observer)
    {
        _observers.Remove(observer);
        Console.WriteLine($"[{Symbol}] Observador removido ({_observers.Count} restantes)");
    }
    
    public void UpdatePrice(decimal newPrice)
    {
        if (Price == newPrice) return;

        _lastChange = new StockPriceChange(Symbol, Price, newPrice);
        Price = newPrice;

        Console.WriteLine($"\n[{Symbol}] Preço atualizado: R$ {_lastChange.OldPrice:N2} → R$ {newPrice:N2} ({_lastChange.ChangePercent:+0.00;-0.00}%)");

        NotifyObservers();
    }
}