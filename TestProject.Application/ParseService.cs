using System.IO;
using System.Text.Json;
using TestProject.Data.Dto;
using TestProject.Data.Models;

namespace TestProject.Application;

public interface IParseService
{
    public MessageData? ParseMessage();
}

public class ParseService : IParseService
{
    public MessageData? ParseMessage()
    {
        using var streamReader = new StreamReader("message.json");
        var messageDataDto = JsonSerializer.Deserialize<MessageDataDto>(streamReader.ReadToEnd());
        if (messageDataDto is null)
            return null;
        return MapMessage(messageDataDto);
    }

    private MessageData? MapMessage(MessageDataDto dto)
    {
        var textData = JsonSerializer.Deserialize<TextDataDto>(dto.TextData);
        if (textData is null) 
            return null;
        var contacts = textData.TextData.ContactInfo;
        var actualAddress = contacts.First(x => x.TypeCI.Name == "Фактический адрес");
        var phone = contacts.First(x => x.TypeCI.Name == "Телефон");

        return new MessageData()
        {
            Guid = Guid.Parse(dto.Guid),
            RegistrationDate = DateTime.Parse(dto.RegistrationDate),
            Name = dto.Name,
            ActualAddress = actualAddress.ViewCI,
            Phone = phone.ViewCI,
        };
    }
}