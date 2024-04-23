using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5.Model.Ernährung
{
    public class DietPlan
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int CaloriesPerDay { get; set; }

        [Required]
        public int ProteinsPerDay { get; set; }
    }
}

