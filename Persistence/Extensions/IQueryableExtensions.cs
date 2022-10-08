using Application.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Paging<T>(this IQueryable<T> query, PagingDto pagingDto)
        {
            return query.Skip((pagingDto.PageIndex-1)*pagingDto.PageSize).Take(pagingDto.PageSize);
        }
    }
}
