using Tlis.Inventory.Core;

namespace Tlis.Inventory.Application.Features.Storage.Scenarios;

public record AddItemWithTags(int CategoryId, string Name, int Quantity, List<string> Tags) : IScenario<int>;