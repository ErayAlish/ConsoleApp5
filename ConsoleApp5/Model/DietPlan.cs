using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnessapp.Model
{
    // Klasse, die die Datenbankentitäten für den Ernährungsplan repräsentiert
    public class DietPlan
    {   
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CaloriesPerDay { get; set; }
        public int ProteinsPerDay { get; set; }
    }
}

