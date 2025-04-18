using System.Text.Json.Serialization;

namespace TestProject.Data.Dto;
public class TextDataDto
{
    [JsonPropertyName("ТекстовыеДанные")]
    public TextDataInner TextData { get; set; } = null!;
}

public class TextDataInner
{
    [JsonPropertyName("КонтактнаяИнформация")]
    public ContactInfo[] ContactInfo { get; set; } = null!;
}

public class ContactInfo
{
    [JsonPropertyName("ВидКИ")]
    public TypeCI TypeCI { get; set; } = null!;

    [JsonPropertyName("ПредставлениеКИ")]
    public string ViewCI { get; set; } = null!;
}

public class TypeCI
{
    [JsonPropertyName("Наименование")]
    public string Name { get; set; } = null!;
}