using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestProject.Data.Models;

namespace TestProject.Data;

public class MessageDataConfig : IEntityTypeConfiguration<MessageData>
{
    public void Configure(EntityTypeBuilder<MessageData> builder)
    {
        builder.ToTable("MessageData");

        builder.Property(p => p.Name).HasMaxLength(50);
    }
}
