using System.Collections.Generic;
using System.Linq;

namespace BoletoService.Shared.Messages
{
    /// <summary>
    /// Entidade base para sucesso na requisição ToList.
    /// </summary>

    public class ResultListSucess<T> : IResultListSucess<T>, IResult where T : IDtoResponse
    {
        public IEnumerable<T?> Itens { get; set; }

        public ResultListSucess(IEnumerable<T?> itens)
        {
            Itens = itens ?? Enumerable.Empty<T>();
        }

        public static IResult New(IEnumerable<T?> itens)
        {
            return new ResultListSucess<T>(itens);
        }
    }
}



