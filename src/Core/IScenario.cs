using MediatR;

namespace Tlis.Inventory.Core;

public interface IScenarioBase;

public interface IScenario : IScenarioBase, IRequest;

public interface IScenario<out TResult> : IScenarioBase, IRequest<TResult>;