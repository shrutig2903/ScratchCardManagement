using ScratchCardManagement.Filters;

namespace ScratchCardManagement.Repository.Abstraction
{
    public interface IUriServices
    {
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}
