namespace BoletoService.Shared.Messages
{
    /// <summary>
    /// interface base para falha de requisição na API.
    /// </summary>
    public interface IResultFailed : IResult
    {
        string? Message { get; set; }
    }
}
