using Application.Features.CQRS.Commands.Category;
using Application.Features.CQRS.Commands.Movie;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.Movie
{
    public class CreateMovieCommandHandler
    {
        private readonly MovieContext _movieContext;

        public CreateMovieCommandHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }
        public async void Handle(CreateMovieCommand command)
        {
            _movieContext.Movies.Add(new Domain.Entities.Movie()
            {
                Title = command.Title,
                Status = command.Status,
                CoverImageUrl = command.CoverImageUrl,
                CreatedYear = command.CreatedYear,
                Description = command.Description,
                Duration = command.Duration,
                Rating = command.Rating,
                ReleaseDate = command.ReleaseDate
            });
            await _movieContext.SaveChangesAsync();
        }
    }
}
