using Application.Features.CQRS.Results.Category;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.Category
{
    public class GetCategoryQueryHandler
    {
        private readonly MovieContext _movieContext;

        public GetCategoryQueryHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }
        public async Task<List<GetCategoryQueryResult>> Handle()
        {
            var values = await _movieContext.Categories.ToListAsync();
            return values?.Select(x=> new GetCategoryQueryResult
            {
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName
            }).ToList() ;
        }
    }
}
