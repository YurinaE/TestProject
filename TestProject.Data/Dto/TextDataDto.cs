using System.Text.Json.Serialization;

namespace TestProject.Data.Dto;
public class TextDataDto
{
    [JsonPropertyName("���������������")]
    public TextDataInner TextData { get; set; } = null!;
}

public class TextDataInner
{
    [JsonPropertyName("��������������������")]
    public ContactInfo[] ContactInfo { get; set; } = null!;
}

public class ContactInfo
{
    [JsonPropertyName("�����")]
    public TypeCI TypeCI { get; set; } = null!;

    [JsonPropertyName("���������������")]
    public string ViewCI { get; set; } = null!;
}

public class TypeCI
{
    [JsonPropertyName("������������")]
    public string Name { get; set; } = null!;
}