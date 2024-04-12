using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnessapp.Model
{    
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Calories { get; set; }
        public int Proteins { get; set; }
        public string TimeOfDay { get; set; }
    }
}
