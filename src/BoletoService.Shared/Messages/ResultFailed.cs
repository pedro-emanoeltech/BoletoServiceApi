namespace BoletoService.Shared.Messages
{
    /// <summary>
    /// Entidade base para Request.
    /// </summary>

    public class ResultFailed : IResultFailed, IResult
    {
        public string? Message { get; set; }

        public static IResult New(string message) => new ResultFailed { Message = message };
    }
}



