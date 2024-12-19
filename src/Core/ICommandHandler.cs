using MediatR;

namespace Tlis.Inventory.Core;

public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand> where TCommand : class, ICommand;

public interface ICommandHandler<in TCommand, TResult> : IRequestHandler<TCommand, TResult> where TCommand : class, ICommand<TResult>;