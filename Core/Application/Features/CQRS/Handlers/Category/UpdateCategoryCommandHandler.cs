﻿using Application.Features.CQRS.Commands.Category;
using Application.Features.CQRS.Commands.Movie;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CQRS.Handlers.Category
{
    public class UpdateCategoryCommandHandler
    {
        private readonly MovieContext _movieContext;

        public UpdateCategoryCommandHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }
        public async void Handle(UpdateCategoryCommand command)
        {
            var value = await _movieContext.Categories.FindAsync(command.CategoryId);
            value.CategoryName = command.CategoryName;
            _movieContext.Categories.Update(value);
            await _movieContext.SaveChangesAsync();
        }
    }
}
