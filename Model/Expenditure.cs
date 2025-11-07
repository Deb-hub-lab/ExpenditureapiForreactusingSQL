using System.ComponentModel.DataAnnotations;

namespace MyExpenditure.Model
{
    public class Expenditure
    {
        [Key]
        public int Id { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public DateTime Date { get; set; }
        // Add the new Remarks column here
        public string Remarks { get; set; } = string.Empty;
    }
}
