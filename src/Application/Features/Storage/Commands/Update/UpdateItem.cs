using Tlis.Inventory.Core;

namespace Tlis.Inventory.Application.Features.Storage.Commands.Update;

public sealed record UpdateItem(int ItemId, string? Name, int? Quantity) : ICommand;