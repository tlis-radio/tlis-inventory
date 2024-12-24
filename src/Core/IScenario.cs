using MediatR;

namespace Tlis.Inventory.Core;

public interface IScenarioBase : IRequest;

public interface IScenario : IScenarioBase;

public interface IScenario<out TResult> : IScenarioBase, IRequest<TResult>;