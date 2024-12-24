using MediatR;

namespace Tlis.Inventory.Core;

public interface IScenarioHandler<in TScenario> : IRequestHandler<TScenario> where TScenario : class, ICommand;

public interface IScenarioHandler<in TScenario, TResult> : IRequestHandler<TScenario, TResult> where TScenario : class, ICommand<TResult>;