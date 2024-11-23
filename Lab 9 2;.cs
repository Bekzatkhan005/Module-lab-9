Lab 9 2;

// Интерфейс для напитков
public interface IBeverage
{
    double GetCost(); // Получить стоимость напитка
    string GetDescription(); // Получить описание напитка
}

// Базовый напиток - Кофе
public class Coffee : IBeverage
{
    public double GetCost()
    {
        return 50.0; // Стоимость кофе
    }

    public string GetDescription()
    {
        return "Coffee";
    }
}

// Абстрактный декоратор для добавок
public abstract class BeverageDecorator : IBeverage
{
    protected IBeverage _beverage;

    public BeverageDecorator(IBeverage beverage)
    {
        _beverage = beverage;
    }

    public virtual double GetCost()
    {
        return _beverage.GetCost(); // Стоимость основного напитка
    }

    public virtual string GetDescription()
    {
        return _beverage.GetDescription(); // Описание основного напитка
    }
}

// Декоратор для молока
public class MilkDecorator : BeverageDecorator
{
    public MilkDecorator(IBeverage beverage) : base(beverage) { }

    public override double GetCost()
    {
        return base.GetCost() + 10.0; // Стоимость с добавлением молока
    }

    public override string GetDescription()
    {
        return base.GetDescription() + ", Milk";
    }
}

// Декоратор для сахара
public class SugarDecorator : BeverageDecorator
{
    public SugarDecorator(IBeverage beverage) : base(beverage) { }

    public override double GetCost()
    {
        return base.GetCost() + 5.0; // Стоимость с добавлением сахара
    }

    public override string GetDescription()
    {
        return base.GetDescription() + ", Sugar";
    }
}

// Декоратор для шоколада
public class ChocolateDecorator : BeverageDecorator
{
    public ChocolateDecorator(IBeverage beverage) : base(beverage) { }

    public override double GetCost()
    {
        return base.GetCost() + 15.0; // Стоимость с добавлением шоколада
    }

    public override string GetDescription()
    {
        return base.GetDescription() + ", Chocolate";
    }
}

// Клиентский код
class Program
{
    static void Main(string[] args)
    {
        // Создаем базовый напиток — кофе
        IBeverage beverage = new Coffee();
        Console.WriteLine($"{beverage.GetDescription()} : {beverage.GetCost()}");

        // Добавляем молоко
        beverage = new MilkDecorator(beverage);
        Console.WriteLine($"{beverage.GetDescription()} : {beverage.GetCost()}");

        // Добавляем сахар
        beverage = new SugarDecorator(beverage);
        Console.WriteLine($"{beverage.GetDescription()} : {beverage.GetCost()}");

        // Добавляем шоколад
        beverage = new ChocolateDecorator(beverage);
        Console.WriteLine($"{beverage.GetDescription()} : {beverage.GetCost()}");
    }
}
