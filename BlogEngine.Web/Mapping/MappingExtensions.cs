using System.Linq;

namespace BlogEngine.Web.Mapping
{
    public static class MappingExtensions
    {
        public static PaginatedList<TDestination> ToPaginatedList<TDestination>(this IQueryable<TDestination> queryable, int pageNumber, int pageSize)
            => PaginatedList<TDestination>.Create(queryable, pageNumber, pageSize);
    }
}
