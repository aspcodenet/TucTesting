

public interface IRouteStrategy
{
    public List<string> Waypoints(string from, string to);
}
public class ShortestRouteStrategy : IRouteStrategy
{
    public List<string> Waypoin(string from, string to)
    {
        return new List<string>
        {
            "Testgatan",
            "Vänster Hejgatan"
        };
    }
}

public class FastestRouteStrategy : IRouteStrategy
{
    public List<string> Waypoints(string from, string to)
    {
        return new List<string>
        {
            "Testgatan",
            "Höger in på Blue Street",
            "Höger in på Kanelvägen",
            "Höger in på Hejgatan"
        };
    }
}

public class MostBeautifulRouteStrategy : IRouteStrategy
{
    public List<string> Waypoints(string from, string to)
    {
        return new List<string>
        {
            "Testgatan till vägen tar slut",
            "Höger över cykelbanan",
            "Kör genom skogen i 2.2 km",
            "Höger in på Hejgatan"
        };
    }
}


public class RouteCalculator
{
    public bool PresentRoute(string from, string to, IRouteStrategy strategy)
    {
        if (!ValidLocation(from)) return false;
        if (!ValidLocation(to)) return false;
        //Calculate best route
        foreach (var route in strategy.Waypoints(from, to))
            Console.WriteLine(route);
        return true;
    }

    private bool ValidLocation(string from)
    {
        //Kolla i databas etc etc
        return true;
    }
}

public class DemoStrategy
{
    public void Run()
    {
        var routeCalulator = new RouteCalculator();


        //När du har saker som du vill BEARBETA på olika sätt beroende på olika faktorer
        //
        IRouteStrategy strategy = null;
        Console.WriteLine("1. Snabbaste");
        Console.WriteLine("2. Vackraste");
        Console.WriteLine("3. Billigaste");
        var sel = Console.ReadLine();
        if (sel == "1")
            strategy = new FastestRouteStrategy();
        else if (sel == "2")
            strategy = new MostBeautifulRouteStrategy();
        else if (sel == "3")
            strategy = new ShortestRouteStrategy();
        var res = routeCalulator.PresentRoute("Uppsala", "Stockholm", strategy);

        // FACTORY!!!


    }
}