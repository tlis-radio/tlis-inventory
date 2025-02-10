using MediatR;
using Tlis.Inventory.Application.Features.Storage.Commands.Create;
using Tlis.Inventory.Core;

namespace Tlis.Inventory.Application.Features.Storage.Scenarios;

public class AddItemWithTagsHandler(IMediator mediator) : IScenarioHandler<AddItemWithTags, int>
{
    public async Task<int> Handle(AddItemWithTags request, CancellationToken cancellationToken)
    {
        (int categoryId, string name, int quantity, List<string> tags) = request;
        
        int itemId = await mediator.Send(new CreateItem(name, categoryId, quantity), cancellationToken);

        foreach (string tag in tags)
        {
            await mediator.Send(new CreateTag(tag), cancellationToken);
            await mediator.Send(new CreateItemToTag(itemId, tag), cancellationToken);
        }

        return itemId;
    }
}