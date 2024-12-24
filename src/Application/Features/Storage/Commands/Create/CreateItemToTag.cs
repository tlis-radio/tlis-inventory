using Tlis.Inventory.Core;

namespace Tlis.Inventory.Application.Features.Storage.Commands.Create;

public sealed record CreateItemToTag(int ItemId, string TagName) : ICommand<(int, string)>;