using MediatR;
using Microsoft.EntityFrameworkCore;
using TestProject.Data;
using TestProject.Data.Models;

namespace TestProject.Application;

public class InsertMessageDataQuery : IRequest<bool>
{
    public InsertMessageDataQuery(MessageData messageData)
    {
        MessageData = messageData;
    }
    public MessageData MessageData { get; set; }
}

public class InsertMessageDataHandler : IRequestHandler<InsertMessageDataQuery, bool>
{
    private readonly IDbContextFactory<TestDbContext> _dbContextFactory;
    public InsertMessageDataHandler(IDbContextFactory<TestDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task<bool> Handle(InsertMessageDataQuery request, CancellationToken cancellationToken)
    {
        var messageData = request.MessageData;

        using var context = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        await context.Messages.AddAsync(messageData);

        try
        {
            await context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }
}
