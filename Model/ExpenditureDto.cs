namespace MyExpenditure.Model
{
    public class ExpenditureDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Remarks { get; set; } = string.Empty; // Add remarks
    }
}
