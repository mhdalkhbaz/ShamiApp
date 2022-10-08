using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Dtos
{
    public class PagingResultDto<T>
    {
        public PagingResultDto(int total, IEnumerable<T> data)
        {
            Total = total;
            Data = data;
        }
        public int Total { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
