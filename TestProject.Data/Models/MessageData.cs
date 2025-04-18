using System.Text.Json.Serialization;

namespace TestProject.Data.Models;
public class MessageData
{
    public int Id { get; set; }
    public Guid Guid { get; set; }
    public DateTime RegistrationDate { get; set; }
    public string Name { get; set; } = null!;
    public string ActualAddress { get; set; } = null!;
    public string Phone { get; set; } = null!;
}
