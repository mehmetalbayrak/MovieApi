using Application.Features.CQRS.Queries.Category;
using Application.Features.CQRS.Results.Category;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.Category
{
    public class GetCategoryByIdQueryHandler
    {
        private readonly MovieContext _movieContext;

        public GetCategoryByIdQueryHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }
        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query)
        {
            var value = await _movieContext.Categories.FindAsync(query.CategoryId);
            return new GetCategoryByIdQueryResult { CategoryId = value.CategoryId, CategoryName = value.CategoryName };
        }
    }
}
