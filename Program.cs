
Logistics logistics;

logistics = new RoadLogistics();
logistics.PlanDelivery();

logistics = new SkyLogistics();
logistics.PlanDelivery();

logistics = new HeavyCargoLogistics();
logistics.PlanDelivery();

Loader loader;

loader = new RoadLoader();
loader.PlanLoader();

loader = new SkyLoader();
loader.PlanLoader();

loader = new HeavyCargoLoader();
loader.PlanLoader();


public interface ITransport
{
    void LoadCargo(ICargo cargo);
    void Deliver();
}

public class Truck : ITransport
{
    public void LoadCargo(ICargo cargo)
    {
        Console.WriteLine($"Загружаем {cargo.GetInfo()} в грузовик.");
    }
    public void Deliver()
    {
        Console.WriteLine($"Deliver by Truck");
    }
    
}

public class Plane : ITransport
{
    public void LoadCargo(ICargo cargo)
    {
        Console.WriteLine($"Загружаем {cargo.GetInfo()} в самолет");

    }
    public void Deliver()
    {
        Console.WriteLine("Deliver by Plane");
    }
}

public interface ICargo
{
    string GetInfo();
}

public class EaseCargo : ICargo
{
    public string GetInfo()
    {
        return "Хрупкий груз";
    }
}
public class HeavyCargo : ICargo
{
    public string GetInfo()
    {
        return "Тяжелый груз";
    }
}
public class PerishableCargo : ICargo
{
    public string GetInfo()
    {
        return "Скоропортящийся груз";
    }
}

public abstract class Logistics
{
    // ФАБРИЧНЫЙ МЕТОД!!!!
    public abstract ITransport CreateTransport();
    public abstract ICargo CreateCargo();

    public void PlanDelivery()
    {
        var transport = CreateTransport();
        var cargo = CreateCargo();
        transport.LoadCargo(cargo);
        transport.Deliver();
    }
}

public abstract class Loader
{
    public abstract ICargo CreateCargo();

    public void PlanLoader()
    {
        var cargo = CreateCargo();
        //Console.WriteLine($"Груз: {cargo.GetInfo()}");
    }
}

public class RoadLogistics : Logistics
{
    public override ITransport CreateTransport()
    {
        return new Truck();
    }
    public override ICargo CreateCargo()
    {
        return new EaseCargo();
    }
}

public class SkyLogistics : Logistics
{
    public override ITransport CreateTransport()
    {
        return new Plane();
    }
    public override ICargo CreateCargo()
    {
        return new PerishableCargo();
    }
}
public class HeavyCargoLogistics : Logistics
{
    public override ITransport CreateTransport()
    {
        return new Truck();
    }

    public override ICargo CreateCargo()
    {
        return new HeavyCargo();
    }
}
public class RoadLoader : Loader
{
    public override ICargo CreateCargo()
    {
        return new EaseCargo();
    }
}

public class SkyLoader : Loader
{
    public override ICargo CreateCargo()
    {
        
        return new PerishableCargo() ;
    }
}

public class HeavyCargoLoader : Loader
{
    public override ICargo CreateCargo()
    {
        return new HeavyCargo();
    }
}