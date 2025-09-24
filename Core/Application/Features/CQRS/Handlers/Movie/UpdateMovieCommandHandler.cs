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
    public class UpdateMovieCommandHandler
    {
        private readonly MovieContext _movieContext;

        public UpdateMovieCommandHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }
        public async void Handle(UpdateMovieCommand command)
        {
            var value = await _movieContext.Movies.FindAsync(command.MovieId);
            value.Status = command.Status;
            value.Title = command.Title;
            value.Description = command.Description;
            value.Duration = command.Duration;
            value.Rating = command.Rating;
            value.CreatedYear = command.CreatedYear;
            value.CoverImageUrl = command.CoverImageUrl;
            _movieContext.Movies.Update(value);
            await _movieContext.SaveChangesAsync();
        }
    }
}
