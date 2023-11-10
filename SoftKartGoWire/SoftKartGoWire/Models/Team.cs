namespace SoftKartGoWire.Models;

public class Team
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<Driver> Drivers { get; set; }
}

public class Driver
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Team Team { get; set; }
}
