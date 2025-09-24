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
    public class RemoveMovieCommandHandler
    {
        private readonly MovieContext _movieContext;

        public RemoveMovieCommandHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }
        public async void Handle(RemoveMovieCommand command)
        {
            var value = await _movieContext.Movies.FindAsync(command.MovieId);
            _movieContext.Movies.Remove(value);
            await _movieContext.SaveChangesAsync();
        }
    }
}
