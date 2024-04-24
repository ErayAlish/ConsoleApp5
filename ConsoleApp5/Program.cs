using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp5.Model.Ernährung;
using Fitnessapp.Model;
using static ConsoleApp5.Daten.FitnessDbContext;
using ConsoleApp5.Model.WorkoutPlan;
using Microsoft.Exchange.WebServices.Data;
using ConsoleApp5.Daten;

namespace FitnessApp
{
    class Program
    {

        
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Willkommen bei der Fitness-App!");
                Console.WriteLine("1. Neue Registrierung");
                Console.WriteLine("2. Alle Registrierungen anzeigen");
                Console.WriteLine("3. Beenden");
                Console.Write("Bitte wählen Sie eine Option: ");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        RegisterUser();
                        break;
                    case "2":
                        ShowAllUsers();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Ungültige Option. Bitte wählen Sie eine gültige Option aus.");
                        break;
                }
            }
        }

        static void RegisterUser()
        {
            Console.WriteLine("\n--- Neue Registrierung ---");
            Console.Write("Geben Sie Ihren Namen ein: ");
            string name = Console.ReadLine();
            Console.Clear();

            Console.Write("Geben Sie Ihr Passwort ein: ");
            string password = GetPassword();
            Console.Clear();

            Console.Write("Geben Sie Ihr Geschlecht ein (Männlich = 'M', Weiblich = 'W'): ");
            char gender = char.Parse(Console.ReadLine().ToUpper());
            Console.Clear();

            Console.Write("Geben Sie Ihr Gewicht in kg ein: ");
            double weight = double.Parse(Console.ReadLine());
            Console.Clear();

            Console.Write("Geben Sie Ihr Alter ein: ");
            int age = int.Parse(Console.ReadLine());
            Console.Clear();

            Console.Write("Geben Sie Ihre Größe in cm ein: ");
            double height = double.Parse(Console.ReadLine());
            Console.Clear();

            Console.Write("Möchten Sie abnehmen oder zunehmen? (abnehmen/zunehmen): ");
            string goal = Console.ReadLine();
            Console.Clear();

            Console.Write("An wie vielen Tagen können Sie pro Woche trainieren? ");
            int trainingDays = int.Parse(Console.ReadLine());
            Console.Clear();

            Console.Write("Wie viele Stunden können Sie pro Tag im Fitnessstudio verbringen? ");
            double trainingHoursPerDay = double.Parse(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("\nGeben Sie Ihre tägliche Aktivität ein:");
            Console.WriteLine("0,2 - Liegend");
            Console.WriteLine("0,4 - Sitzend");
            Console.WriteLine("0,6 - Stehend");
            Console.WriteLine("0,8 - Stehend/Gehend");
            Console.WriteLine("1,0 - Körperlich hart arbeitend");
            Console.Write("Bitte geben Sie den Wert ein: ");
            double dailyActivity = double.Parse(Console.ReadLine());

            using (var db = new FitnessContext())
            {
                var user = new User
                {
                    Name = name,
                    Weight = weight,
                    Age = age,
                    Height = height,
                    Gender = gender,
                    DailyActivity = dailyActivity,
                    Goal = goal,
                    TrainingDays = trainingDays,
                    TrainingHoursPerDay = trainingHoursPerDay,

                };

                db.Users.Add(user); 
                db.SaveChanges();

                Console.WriteLine("Benutzer erfolgreich registriert!");

                ///Ernährungsplan generieren
                // GenerateDietPlan(user, db);

                Console.Clear();
                Console.WriteLine("1. Trainingsplan erstellen");
                Console.WriteLine("2. Ernährungsplan erstellen");
                string option2 = Console.ReadLine();
                switch (option2)
                {

                    case "1":
                        CreateWorkoutPlan(user, db);
                        break;
                    case "2":
                        GenerateDietPlan(user, db);
                        break;

                }


            }
        }
       
       
        static void CreateWorkoutPlan(User user, FitnessContext db)
        {

            Console.WriteLine("Trainingsplan wird erstellt...");
            var trainingPlan = new TrainingsPlan();

            if (user.TrainingDays <= 3)
            {
                // Fullbody-Trainingsplan für 2-3 Trainingstage pro Woche
                CreateFullbodyWorkout(trainingPlan, user.TrainingHoursPerDay, db);
            }
            else
            {
                // Split-Trainingsplan für 4 oder mehr Trainingstage pro Woche
                // CreateSplitWorkout(trainingPlan, user.TrainingHoursPerDay, db);
            }

            db.TrainingsPlans.Add(trainingPlan);
            db.SaveChanges();
        }

        static void CreateFullbodyWorkout(TrainingsPlan trainingsPlan, double trainingHoursPerDay, FitnessContext db)
        {

            var TrainingsPlan = new TrainingsPlan();
            trainingsPlan.Name = "Fullbody Trainingsplan";
            trainingsPlan.UserID = trainingsPlan.UserID;




            // Übungen für Fullbody-Training
            var aktivitäten = new List<Aktivitäten>
           {
                // Bizeps
              new Aktivitäten { Name = "Bizepscurls mit Langhantel",Dauer = 15, Wdh = 3, WdhPS = 10, Typ = "Bizeps" },
              new Aktivitäten { Name = "Hammercurls",Dauer = 15, Wdh = 3, WdhPS = 10, Typ = "Bizeps" },
              new Aktivitäten { Name = "Konzentrationscurls",Dauer = 15, Wdh = 3, WdhPS = 10, Typ = "Bizeps" },

               // Beine
              new Aktivitäten { Name = "Kniebeugen", Dauer = 15,Wdh = 4, WdhPS = 10, Typ = "Beine" },
              new Aktivitäten { Name = "Ausfallschritte",Dauer = 15, Wdh = 3, WdhPS = 12, Typ = "Beine" },
              new Aktivitäten { Name = "Beinpressen",Dauer = 15, Wdh = 3, WdhPS = 10, Typ = "Beine" },

             // Brust
              new Aktivitäten { Name = "Bankdrücken mit Langhantel",Dauer = 15, Wdh = 4, WdhPS = 10, Typ = "Brust" },
              new Aktivitäten { Name = "Butterfly", Dauer = 15,Wdh = 3, WdhPS = 12, Typ = "Brust" },
              new Aktivitäten { Name = "Schrägbankdrücken",Dauer = 15, Wdh = 3, WdhPS = 10, Typ = "Brust" },

                // Rücken
              new Aktivitäten { Name = "Klimmzüge",Dauer = 15, Wdh = 3, WdhPS = 10, Typ = "Rücken" },
              new Aktivitäten { Name = "Rudern am Kabelzug",Dauer = 15, Wdh = 3, WdhPS = 12, Typ = "Rücken" },
              new Aktivitäten { Name = "Kreuzheben",Dauer = 15, Wdh = 4, WdhPS = 10, Typ = "Rücken" },

               // Schultern
              new Aktivitäten { Name = "Schulterdrücken mit Kurzhanteln", Dauer = 15, Wdh = 4, WdhPS = 10, Typ = "Schultern" },
              new Aktivitäten { Name = "Seitenheben",Dauer = 15, Wdh = 3, WdhPS = 12, Typ = "Schultern" },
              new Aktivitäten { Name = "Frontheben",Dauer = 15, Wdh = 3, WdhPS = 10, Typ = "Schultern" },

              // Trizeps
              new Aktivitäten { Name = "Trizepsdrücken am Kabelzug",Dauer = 15, Wdh = 4, WdhPS = 10, Typ = "Trizeps" },
              new Aktivitäten { Name = "Dips",Dauer = 15, Wdh = 3, WdhPS = 12, Typ = "Trizeps" },
              new Aktivitäten { Name = "French Press", Dauer = 15,Wdh = 3, WdhPS = 10, Typ = "Trizeps" },

              // Bauch
              new Aktivitäten { Name = "Russian Twists", Dauer = 15,Wdh = 3, WdhPS = 15, Typ = "Bauch" },
              new Aktivitäten { Name = "Beinheben",Dauer = 15, Wdh = 3, WdhPS = 12, Typ = "Bauch" },
              new Aktivitäten { Name = "Crunches",Dauer = 15, Wdh = 3, WdhPS = 15, Typ = "Bauch" },

              // Waden
              new Aktivitäten { Name = "Wadenheben",Dauer = 15, Wdh = 4, WdhPS = 15, Typ = "Waden" },
              new Aktivitäten { Name = "Stehendes Wadenheben",Dauer = 15, Wdh = 3, WdhPS = 15, Typ = "Waden" },
              new Aktivitäten { Name = "Sitzendes Wadenheben",Dauer = 15, Wdh = 3, WdhPS = 15, Typ = "Waden" }
            };

            var groupedActivities = aktivitäten.GroupBy(a => a.Typ).ToDictionary(g => g.Key, g => g.ToList());

            int totalDuration = 0;
            var selectedActivities = new List<Aktivitäten>();

            foreach (var kvp in groupedActivities)
            {
                var activitiesOfType = kvp.Value;

                foreach (var activity in activitiesOfType)
                {
                    int duration = activity.Dauer; // Hier wird die Dauer der Aktivität verwendet
                    if (totalDuration + duration <= trainingHoursPerDay * 60)
                    {
                        selectedActivities.Add(activity);
                        totalDuration += duration;
                    }
                    
                }
            }

            foreach (var activity in aktivitäten)
            {
                trainingsPlan.Aktivitäten.Add(activity);
            }



            db.TrainingsPlans.Add(trainingsPlan);
            db.SaveChanges();

            Console.Clear();
            Console.WriteLine("\n--- Erstellter Trainingsplan ---");
            Console.WriteLine($"Name: {trainingsPlan.Name}");
            Console.WriteLine($"Benutzer ID: {trainingsPlan.UserID}");
            Console.WriteLine("Aktivitäten:");
            foreach (var activity in trainingsPlan.Aktivitäten)
            {
                Console.WriteLine($"- {activity.Name}, Dauer: {activity.Dauer}, Wiederholungen: {activity.Wdh}, Wiederholungen pro Satz: {activity.WdhPS}, Typ: {activity.Typ}");
            }
            Console.ReadKey();

        }


        static void CreateSplitWorkout(TrainingsPlan workoutPlan, double trainingHoursPerDay, FitnessContext db)
        {
            workoutPlan.Name = "Split Trainingsplan";

            // Übungen für Split-Training
            var exercises = new List<Aktivitäten>
            {
                // Push Day
              //  new Aktivitäten { Name = "Bankdrücken mit Kurzhanteln", Dauer = "25 Minuten", Typ = "Brust" },
            };
        }


        static void GenerateDietPlan(User user, FitnessContext db)
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

            // Berechnung des täglichen Kalorienbedarfs basierend auf Geschlecht, Aktivität und Ziel
            double bmr;
            if (user.Gender == 'M')
            {
                bmr = 66.5 + (13.7 * user.Weight) + (5.0 * user.Height) - (6.8 * user.Age);
            }
            else // Weiblich
            {
                bmr = 655 + (9.6 * user.Weight) + (1.8 * user.Height) - (4.7 * user.Age);
            }

            double calorieMultiplier = 1.0;
            if (user.DailyActivity == 0.2)
            {
                calorieMultiplier = 1.2;
            }
            else if (user.DailyActivity == 0.4)
            {
                calorieMultiplier = 1.4;
            }
            else if (user.DailyActivity == 0.6)
            {
                calorieMultiplier = 1.6;
            }
            else if (user.DailyActivity == 0.8)
            {
                calorieMultiplier = 1.8;
            }
            else if (user.DailyActivity == 1.0)
            {
                calorieMultiplier = 2.0;
            }

            double maintenanceCalories = bmr * calorieMultiplier;

            if (user.Goal == "abnehmen")
            {
                maintenanceCalories -= 150; // Kalorienreduktion für Gewichtsverlust
            }
            else if (user.Goal == "zunehmen")
            {
                maintenanceCalories += 250; // Kalorienzufuhr für Gewichtszunahme
            }

           

            // Ernährungsplan speichern
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
            Console.WriteLine("\n--- Ernährungsplan ---");
            for (int i = 0; i < 7; i++)
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

        static void ShowAllUsers()
        {

            Console.Clear();
            Console.WriteLine("Bitte geben Sie den Passwort ein");
            string password = GetPassword();

            if (password == "1234")
            {
                using (var db = new FitnessContext())
                {
                    var users = db.Users.ToList();
                    if (users.Any())
                    {
                        Console.WriteLine("\n--- Alle Registrierungen ---");
                        foreach (var user in users)
                        {
                            Console.WriteLine($"Name: {user.Name}, Gewicht: {user.Weight} kg, Alter: {user.Age}, Größe: {user.Height} m, Ziel: {user.Goal}, Trainingstage: {user.TrainingDays}, Stunden pro Tag: {user.TrainingHoursPerDay}");

                        }

                        Console.ReadKey();
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("Es sind keine Registrierungen vorhanden.");
                        Console.ReadKey();
                    }
                }
            }
        }
        static string GetPassword()
        {
            string password = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true); // Die Eingabe wird nicht auf der Konsole angezeigt

                if (key.Key != ConsoleKey.Enter)
                {
                    password += key.KeyChar;
                }
            }
            while (key.Key != ConsoleKey.Enter);

            return password;
        }
    } 
}

