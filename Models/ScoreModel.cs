using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class ScoreModel
    {
        [Key]
        public int ScoreId { get; set; }
        [Required(ErrorMessage = "Please enter a date.")]
        public string Date { get; set; }
        [Required(ErrorMessage = "Please enter a score.")]
        public int? Score { get; set; }
        
    }
}
