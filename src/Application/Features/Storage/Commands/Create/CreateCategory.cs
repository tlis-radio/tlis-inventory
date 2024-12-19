using Tlis.Inventory.Core;

namespace Tlis.Inventory.Application.Features.Storage.Commands.Create;

public sealed record CreateCategory(string Name) : ICommand<int>;