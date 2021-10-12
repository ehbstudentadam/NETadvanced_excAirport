// See https://aka.ms/new-console-template for more information
using AirportAdam;

Console.WriteLine("Airport Adam");
AtcTower tower = new AtcTower();

int exit = 0;
while (exit != 6)
{
    Console.WriteLine();
    exit = menu();
    if (exit == 1)
    {
        string code = "";
        while (code.Length < 2 || code.Length > 10)
        {            
            Console.WriteLine("Enter new Runway code:");
            Console.Write("> ");
            code = Console.ReadLine();
            if (code.Length < 2 || code.Length > 10)
            {
                Console.WriteLine("Must be 2 - 10 character long.");
            }
        }
        tower.Runways.Add(new Runway(code));
        Console.WriteLine(tower.RunwaySummary());
    }   // > Add runway with string.Length check
    if (exit == 2)
    {
        Console.WriteLine(tower.RegisterAircraft(new Aircraft()));
        Console.WriteLine(tower.AircraftSummary());
    }   // > Add random generated Aircraft
    if (exit == 3)
    {
        Console.WriteLine(tower.RunwaySummary());
        Console.WriteLine(tower.AircraftSummary());
    }   // > Returns overview of all aircraft and runways
    if (exit == 4)
    {
        Console.WriteLine("Enter flightnumber:");
        Console.Write("> ");
        string code = Console.ReadLine();
        Console.WriteLine(tower.RequestForTakeoff(code));
    }   // > Request for takeoff
    if (exit == 5)
    {
        string code = "";
        while (tower.FindAircraft(code) == null)
        {
            Console.WriteLine("Enter flightnumber:");
            Console.Write("> ");
            code = Console.ReadLine();
            if (tower.FindAircraft(code) == null)
            {
                Console.WriteLine("Flightnumber has not been registered here.");
            }
        }
        Console.WriteLine(tower.FindAircraft(code).Liftoff());
    }   // > Takeoff with flightnumber check
}



int menu ()
{
    Console.WriteLine("Air Trafic Control Tower - Menu:");
    Console.WriteLine("1. Add runway.");
    Console.WriteLine("2. Register aircraft.");
    Console.WriteLine("3. Summary ATC Tower.");
    Console.WriteLine("4. Request for takeoff.");
    Console.WriteLine("5. Takeoff.");
    Console.WriteLine("6. Quit.");
    Console.Write("> ");


    int choice = 0;
    try
    {
        string x = Console.ReadLine();
        choice = Convert.ToInt32 (x);
    }
    catch (Exception)
    {
        Console.WriteLine();
        Console.Write("Only numbers allowed ");
    }

    if (choice < 1 || choice > 6)
    {
        Console.WriteLine("FROM 1-6!");
        Console.WriteLine();
    }

    return choice;
}