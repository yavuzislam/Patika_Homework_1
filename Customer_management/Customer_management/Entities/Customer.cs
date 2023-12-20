using System.ComponentModel.DataAnnotations.Schema;

namespace Customer_management.Entities;

public class Customer
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime BirthDate { get; set; }
    public string Job { get; set; }
    public string Country { get; set; }
    public int IncomeLevelId { get; set; }
    public int MartialStatusId { get; set; }
}