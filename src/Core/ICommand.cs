using MediatR;

namespace Tlis.Inventory.Core;

public interface ICommandBase : IRequest;

public interface ICommand : ICommandBase;

public interface ICommand<out TResult> : ICommandBase, IRequest<TResult>;