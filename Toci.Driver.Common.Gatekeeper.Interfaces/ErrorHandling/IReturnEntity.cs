namespace Toci.Driver.Common.Gatekeeper.Interfaces.ErrorHandling
{
    public interface IReturnEntity<TEntity>
    {
        TEntity Result { get; set; }

        IErrorEntity Error { get; set; }

        bool IsError { get; set; }
    }
}