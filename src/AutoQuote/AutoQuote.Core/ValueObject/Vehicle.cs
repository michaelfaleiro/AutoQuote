namespace AutoQuote.Core.ValueObject;

public class Vehicle : ValueObject
{
    public Vehicle(
        string plate, string chassis, string renavam, string model,
        string manufacturer, int year, string color, string engine)
    {
        Plate = plate;
        Chassis = chassis;
        Renavam = renavam;
        Model = model;
        Manufacturer = manufacturer;
        Year = year;
        Color = color;
        Engine = engine;
    }
    
    public string Plate { get;  set; } 
    public string Chassis { get;  set; } 
    public string Renavam { get;  set; } 
    public string Model { get;  set; } 
    public string Manufacturer { get;  set; } 
    public int Year { get;  set; }
    public string Color { get;  set; } 
    public string Engine { get;  set; } 
    
}