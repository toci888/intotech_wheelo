namespace Toci.Driver.Common.Gatekeeper.Interfaces.ErrorHandling
{
    public interface IErrorFormatter
    {
        void FormatError(IErrorEntity errorEntity, string applicationErrorMessage, string userErrorMessage);
    }
}