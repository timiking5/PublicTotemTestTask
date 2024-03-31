namespace Models;

public class ExpenditureRecord
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int CategoryId { get; set; }
    [ForeignKey("CategoryId"), ValidateNever]
    public Category Category { get; set; }
    [Required]
    public decimal Amount { get; set; }
    [Required]
    public DateTime Date { get; set; }
    [Required]
    public string Description { get; set; }
}
