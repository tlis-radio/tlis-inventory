using MediatR;

namespace Tlis.Inventory.Core;

public interface IQueryHandler<in TQuery, TResult> : IRequestHandler<TQuery, TResult> where TQuery : class, IQuery<TResult>;