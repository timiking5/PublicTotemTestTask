namespace Models.ViewModels;
public class ReportVM
{
    public List<ExpenditureRecord> AggregateByCategory { get; set; }
    public List<ExpenditureRecord> AllRecords { get; set; }
    public DateTime Date { get; set; }
}
