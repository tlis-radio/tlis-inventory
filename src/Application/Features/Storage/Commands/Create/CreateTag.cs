using Tlis.Inventory.Core;

namespace Tlis.Inventory.Application.Features.Storage.Commands.Create;

public sealed record CreateTag(string Name) : ICommand<string>;