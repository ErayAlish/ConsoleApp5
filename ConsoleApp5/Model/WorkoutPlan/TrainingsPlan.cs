using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp5.Model.WorkoutPlan;

namespace ConsoleApp5.Model.WorkoutPlan
{
    public class TrainingsPlan
    {
        public int Id { get; set; }

        [Required]
        public int UserID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Dauer { get; set; }

        public List<Aktivitäten> Aktivitäten { get; set; } = new List<Aktivitäten>();
    }
}
