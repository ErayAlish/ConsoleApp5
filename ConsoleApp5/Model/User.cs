using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitnessapp.Model
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        private string Password { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public double Height { get; set; }

        [Required]
        public char Gender { get; set; } // 'M' für männlich, 'W' für weiblich

        [Required]
        public double DailyActivity { get; set; } // Tägliche Aktivität

        [Required]
        public string Goal { get; set; } // Abnehmen oder Zunehmen

        [Required]
        public int TrainingDays { get; set; }

        [Required]
        public double TrainingHoursPerDay { get; set; }
    }
}
