using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5.Model.WorkoutPlan
{
    public class Aktivitäten
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Wdh { get; set; }

        [Required]
        public int WdhPS { get; set;}

        [Required]
        public int Dauer { get; set; }

        [Required]
        public string Typ { get; set; }

    }
}
