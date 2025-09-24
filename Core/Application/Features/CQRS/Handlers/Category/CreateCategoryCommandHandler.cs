using Persistence.Context;
using Application.Features.CQRS.Commands.Category;

namespace Application.Features.CQRS.Handlers.Category
{
    public class CreateCategoryCommandHandler
    {
        private readonly MovieContext _movieContext;

        public CreateCategoryCommandHandler(MovieContext movieContext)
        {
            _movieContext = movieContext;
        }
        public async Task Handle(CreateCategoryCommand command)
        {
            _movieContext.Categories.Add(new Domain.Entities.Category()
            {
                CategoryName = command.CategoryName
            });
            await _movieContext.SaveChangesAsync();
        }
    }
}
