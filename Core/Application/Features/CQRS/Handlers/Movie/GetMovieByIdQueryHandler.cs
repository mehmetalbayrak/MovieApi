using Application.Features.CQRS.Queries.Category;
using Application.Features.CQRS.Queries.Movie;
using Application.Features.CQRS.Results.Category;
using Application.Features.CQRS.Results.Movie;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.Movie
{
    public class GetMovieByIdQueryHandler
    {
        private readonly MovieContext _movieContext;

        public GetMovieByIdQueryHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }
        public async Task<GetMovieByIdQueryResult> Handle(GetMovieByIdQuery query)
        {
            var value = await _movieContext.Movies.FindAsync(query.MovieId);
            return new GetMovieByIdQueryResult
            {
                Rating = value.Rating,
                CoverImageUrl = value.CoverImageUrl,
                CreatedYear = value.CreatedYear,
                Description = value.Description,
                Duration = value.Duration,
                MovieId = value.MovieId,
                ReleaseDate = value.ReleaseDate,
                Status = value.Status,
                Title = value.Title
            };
        }
    }
}
