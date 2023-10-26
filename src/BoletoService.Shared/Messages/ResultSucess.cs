namespace BoletoService.Shared.Messages
{
    /// <summary>
    /// Entidade base para sucesso na requisição.
    /// </summary>

    public class ResultSucess<T> : IResultSucess<T>, IResult where T : IDtoResponse
    {
        public T? Data { get; set; }

        public static IResult New(T data)
        {
            return new ResultSucess<T>
            {
                Data = data
            };
        }
    }
}



