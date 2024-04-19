using System;
using ConsoleApp5.Daten;
using Fitnessapp.Model;
using Fitnessapp;
using static ConsoleApp5.Daten.FitnessDbContext;


 
// Benutzerdaten abfragen
Console.WriteLine("Willkommen bei der Fitness-App!");
Console.Write("Geben Sie Ihren Namen ein: ");
string name = Console.ReadLine();

Console.Write("Geben Sie Ihr Gewicht in kg ein: ");
double weight = double.Parse(Console.ReadLine());

Console.Write("Geben Sie Ihr Alter ein: ");
int age = int.Parse(Console.ReadLine());

Console.Write("Geben Sie Ihre Größe in Metern ein: ");
double height = double.Parse(Console.ReadLine());

Console.Write("Möchten Sie abnehmen oder zunehmen? (abnehmen/zunehmen): ");
string goal = Console.ReadLine();

Console.Write("An wie vielen Tagen können Sie pro Woche trainieren? ");
int trainingDays = int.Parse(Console.ReadLine());

2Console.Write("Wie viele Stunden können Sie pro Tag im Fitnessstudio verbringen? ");
double trainingHoursPerDay = double.Parse(Console.ReadLine());

// Benutzerdaten speichern
using (var db = new FitnessContext())
{
    var user = new User
    {
        Name = name,
        Weight = weight,
        Age = age,
        Height = height,
        Goal = goal,
                
        TrainingDays = trainingDays,
        TrainingHoursPerDay = trainingHoursPerDay
    };

    db.Users.Add(user);
    db.SaveChanges();
    
   
}

// Ernährungsplan generieren und speichern
using (var db = new FitnessContext())
{
    // Liste von Mahlzeiten
    var meals = new List<Meal>
    {
        new Meal { Name = "Haferflocken mit Milch und Banane", Calories = 300, Proteins = 10, TimeOfDay = "Frühstück" },
        new Meal { Name = "Omelett mit Gemüse", Calories = 350, Proteins = 20, TimeOfDay = "Frühstück" },
        new Meal { Name = "Vollkornbrot mit Avocado", Calories = 250, Proteins = 8, TimeOfDay = "Frühstück" },
        new Meal { Name = "Gegrilltes Hähnchen mit Quinoa und Gemüse", Calories = 400, Proteins = 30, TimeOfDay = "Mittagessen" },
        new Meal { Name = "Linsensuppe mit Vollkornbrot", Calories = 300, Proteins = 15, TimeOfDay = "Mittagessen" },
        new Meal { Name = "Salat mit Thunfisch und Vollkornnudeln", Calories = 350, Proteins = 25, TimeOfDay = "Mittagessen" },
        new Meal { Name = "Gebackener Lachs mit Süßkartoffeln und Brokkoli", Calories = 450, Proteins = 35, TimeOfDay = "Abendessen" },
        new Meal { Name = "Gemüsepfanne mit Tofu und Vollkornreis", Calories = 400, Proteins = 20, TimeOfDay = "Abendessen" },
        new Meal { Name = "Hühnersuppe mit Gemüse", Calories = 300, Proteins = 25, TimeOfDay = "Abendessen" },
        new Meal { Name = "Griechischer Joghurt mit Beeren", Calories = 200, Proteins = 15, TimeOfDay = "Snack" },
        new Meal { Name = "Karottensticks mit Hummus", Calories = 150, Proteins = 5, TimeOfDay = "Snack" },
        new Meal { Name = "Mandeln und getrocknete Früchte", Calories = 250, Proteins = 10, TimeOfDay = "Snack" }
    };
                
    // Ernährungsplan speichern
        
    var user = db.Users.First(u => u.Name == name);
    var dietPlan = new DietPlan
    {
        UserId = user.Id,
        CaloriesPerDay = (user.Goal == "abnehmen") ? 1800 : 2300,
        ProteinsPerDay = (user.Goal == "abnehmen") ? 120 : 150
    };
    db.DietPlans.Add(dietPlan);
    db.SaveChanges();

    // Zufällige Mahlzeiten für jeden Tag generieren
    var random = new Random();
    for (int i = 0; i < user.TrainingDays; i++)
    {
        Console.WriteLine($"\nTag {i + 1}:");
        var dailyMeals = meals.OrderBy(m => random.Next()).GroupBy(m => m.TimeOfDay);
        foreach (var mealGroup in dailyMeals)
        {
            var randomMeal = mealGroup.ElementAt(random.Next(mealGroup.Count()));
            Console.WriteLine($"{mealGroup.Key}: {randomMeal.Name} ({randomMeal.Calories} kcal, {randomMeal.Proteins} g Proteine)");
        }
    }
}
