using System.Text.Json.Serialization;

namespace TestProject.Data.Dto;
public class MessageDataDto
{
    [JsonPropertyName("ГУИД")]
    public string Guid { get; set; } = null!;

    [JsonPropertyName("ДатаРегистрации")]
    public string RegistrationDate { get; set; } = null!;

    [JsonPropertyName("Наименование")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("ТекстовыеДанные")]
    public string TextData { get; set; } = null!;
}
