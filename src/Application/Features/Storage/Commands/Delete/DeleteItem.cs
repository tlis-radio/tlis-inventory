using Tlis.Inventory.Core;

namespace Tlis.Inventory.Application.Features.Storage.Commands.Delete;

public sealed record DeleteItem(int ItemId) : ICommand;