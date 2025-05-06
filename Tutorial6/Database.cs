using Tutorial6.Models;

namespace Tutorial6;

public static class Database
{
    
    public static List<Animal> Animals = new List<Animal>()
    {
        new Animal() { Id = 1, Name = "Puszek", Category = "pies", Weight = 5.5 , FurColor = "red" },
        new Animal() { Id = 2, Name = "Reksio", Category = "pies", Weight = 3.4 , FurColor = "white" },
        new Animal() { Id = 3, Name = "Mruczek", Category = "kot", Weight = 3.9 , FurColor = "grey" }
    };
    
    public static List<Visit> Visits = new List<Visit>()
    {
        new Visit { Id = 1, AnimalId = 1, VisitDate = DateTime.Now.AddDays(-15), Description = "vaccination", Price = 150 },
        new Visit { Id = 2, AnimalId = 2, VisitDate = DateTime.Now.AddDays(-8), Description = "general", Price = 80 }
    };

    
}