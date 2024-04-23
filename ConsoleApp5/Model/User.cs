using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnessapp.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public int Age { get; set; }
        public double Height { get; set; }
        public string Goal { get; set; }
        public int TrainingDays { get; set; }
        public double TrainingHoursPerDay { get; set; }
    }
}
