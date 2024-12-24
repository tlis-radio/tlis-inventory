using Tlis.Inventory.Core;

namespace Tlis.Inventory.Application.Features.Storage.Commands.Create;

public sealed record CreateItem(string Name, int CategoryId, int Quantity = 1) : ICommand<int>;