using MediatR;

namespace Wishlist.Application.SearchCategories;

public record SearchCategoryQuery : IRequest<IEnumerable<CategoryResponse>>;
