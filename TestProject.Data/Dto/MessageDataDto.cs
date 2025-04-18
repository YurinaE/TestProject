using System.Text.Json.Serialization;

namespace TestProject.Data.Dto;
public class MessageDataDto
{
    [JsonPropertyName("����")]
    public string Guid { get; set; } = null!;

    [JsonPropertyName("���������������")]
    public string RegistrationDate { get; set; } = null!;

    [JsonPropertyName("������������")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("���������������")]
    public string TextData { get; set; } = null!;
}
