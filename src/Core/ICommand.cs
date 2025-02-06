using MediatR;

namespace Tlis.Inventory.Core;

public interface ICommandBase;

public interface ICommand : IRequest;

public interface ICommand<out TResult> : IRequest<TResult>, ICommandBase;