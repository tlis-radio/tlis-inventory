using MediatR;

namespace Tlis.Inventory.Core;

public interface IScenarioHandler<in TScenario> : IRequestHandler<TScenario> where TScenario : class, IScenario;

public interface IScenarioHandler<in TScenario, TResult> : IRequestHandler<TScenario, TResult> where TScenario : class, IScenario<TResult>;