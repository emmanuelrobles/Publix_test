// See https://aka.ms/new-console-template for more information

using Application.Interfaces;
using Application.Services;

// creates a service
var service = new ApplicationService(new Settings { DemeritPoints = 1, SpeedDelta = 5 });

try
{
    Console.Write("Speed Limit:");
    var speedLimit = int.Parse(Console.ReadLine() ?? string.Empty);
    Console.Write("Driver Speed:");
    var driverSpeed = int.Parse(Console.ReadLine() ?? string.Empty);

    Console.WriteLine($"Demerit Points: {service.GetDemerit(driverSpeed,speedLimit)}");
}
catch (InvalidCastException)
{
    Console.WriteLine("Cant cast to an int :|");
}



class Settings : ISettings
{
    public uint SpeedDelta { get; init; }
    public uint DemeritPoints { get; init; }
}