using Tlis.Inventory.Core;

namespace Tlis.Inventory.Application.Features.Storage.Commands.Delete;

public sealed record DeleteItemToTag(int ItemId, string TagName) : ICommand;