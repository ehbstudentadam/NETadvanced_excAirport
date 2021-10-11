// See https://aka.ms/new-console-template for more information
using AirportAdam;

Console.WriteLine("Airport Adam");
AtcTower tower = new AtcTower();

int exit = 0;
while (exit != 6)
{
    exit = menu();
    if (exit == 1)
    {
        Console.WriteLine("Enter new Runway code:");
        string code = Console.ReadLine();
        tower.Runways.Add(new Runway(code));
        Console.WriteLine(tower.RunwaySummary());   //HIER DEZE LIJN PRINT NIET JUIST AF
    }
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


    int choice = 0;
    try
    {
        string x = Console.ReadLine();
        choice = Convert.ToInt32 (x);
    }
    catch (Exception)
    {
        Console.Write("Only numbers allowed ");
    }

    if (choice < 1 || choice > 6)
    {
        Console.WriteLine("FROM 1-6!");
    }

    return choice;
}