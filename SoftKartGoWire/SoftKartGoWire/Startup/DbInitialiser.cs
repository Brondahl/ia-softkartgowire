using SoftKartGoWire.Models;

namespace SoftKartGoWire.Startup;

public static class DbInitializer
{
    public static void Initialize(KartingContext context)
    {
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();

        if (context.Teams.Any())
        {
            return;   // DB has been seeded
        }

        var teams = new[]
        {
            new Team{Name="Bobs Brethrin"},
            new Team{Name="Crash Test Dummies"},
            new Team{Name="Gardinering Leave"},
            new Team{Name="Go Kart Schmo Kart"},
            new Team{Name="Harry's team"},
            new Team{Name="Joey Gold"},
            new Team{Name="Not Fast but Furious"},
            new Team{Name="SloMoRail"},
            new Team{Name="SMIRL Spaghetti"},
            new Team{Name="The Kartel"},
            new Team{Name="TriHards"},
        }.ToDictionary(team => team.Name);
        context.Teams.AddRange(teams.Values);

        var drivers = new[]
        {
            new Driver{Name="Christian Sophocleous", Team = teams["Bobs Brethrin"]},
            new Driver{Name="Luke Stuart", Team = teams["Bobs Brethrin"]},

            new Driver{Name="Placeholder01", Team = teams["Crash Test Dummies"]},

            new Driver{Name="Placeholder02", Team = teams["Gardinering Leave"]},

            new Driver{Name="Placeholder03", Team = teams["Go Kart Schmo Kart"]},

            new Driver{Name="Placeholder04", Team = teams["Harry's team"]},

            new Driver{Name="Placeholder05", Team = teams["Joey Gold"]},

            new Driver{Name="Placeholder06", Team = teams["Not Fast but Furious"]},

            new Driver{Name="Placeholder07", Team = teams["SloMoRail"]},

            new Driver{Name="Placeholder08", Team = teams["SMIRL Spaghetti"]},

            new Driver{Name="Placeholder09", Team = teams["The Kartel"]},

            new Driver{Name="Mike McLean", Team = teams["TriHards"]},
            new Driver{Name="Phil Marsden", Team = teams["TriHards"]},
            new Driver{Name="Callum Griffiths", Team = teams["TriHards"]},
        }.ToDictionary(driver => driver.Name);
        context.Drivers.AddRange(drivers.Values);

        context.SaveChanges();
    }
}
