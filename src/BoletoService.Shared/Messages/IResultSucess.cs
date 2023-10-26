namespace BoletoService.Shared.Messages
{
    /// <summary>
    /// interface base de requisição bem sucedida na API.
    /// </summary>
    public interface IResultSucess<T> : IResult where T : IDtoResponse
    {
        T? Data { get; set; }
    }
}
