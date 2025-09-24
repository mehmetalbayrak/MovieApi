using Application.Features.CQRS.Results.Category;
using Application.Features.CQRS.Results.Movie;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.Movie
{
    public class GetMovieQueryHandler
    {
        private readonly MovieContext _movieContext;

        public GetMovieQueryHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }
        public async Task<List<GetMovieQueryResult>> Handle()
        {
            var values = await _movieContext.Movies.ToListAsync();
            return values?.Select(x => new GetMovieQueryResult
            {
               CoverImageUrl = x.CoverImageUrl,
               CreatedYear = x.CreatedYear,
               Description = x.Description,
               Duration = x.Duration,
               MovieId = x.MovieId,
               Rating = x.Rating,
               ReleaseDate = x.ReleaseDate,
               Status = x.Status,
               Title = x.Title,
            }).ToList();
        }
    }
}
