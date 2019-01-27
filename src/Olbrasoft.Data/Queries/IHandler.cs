namespace Olbrasoft.Data.Queries
{
    public interface IHandler<in TQuery, TResult> : IHandle<TQuery, TResult>, IHandleAsync<TQuery, TResult> where TQuery : IQuery<TResult>
    {

    }
}