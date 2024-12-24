using Tlis.Inventory.Core;

namespace Tlis.Inventory.Application.Features.Storage.Commands.Update;

public sealed record UpdateCategory(int CategoryId, string? Name) : ICommand;