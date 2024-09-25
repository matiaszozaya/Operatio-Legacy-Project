using System.ComponentModel.DataAnnotations;

namespace MVC_App.Models
{
    public class OperationViewModel
    {
        [Required]
        public int Id { get; set; }
        public string Type { get; set; }
        public string Account { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal? AmountARS { get; set; }
        public decimal? AmountUSD { get; set; }
        public DateTime? Date { get; set; }
    }
}
