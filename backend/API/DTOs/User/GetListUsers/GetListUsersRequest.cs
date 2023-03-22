using API.Queries;

namespace API.DTOs.User.GetListUsers
{
    public class GetListUsersRequest
    {
        public GetListUsersRequest(
        PagingQuery pagingQuery,
        FilterQuery filterQuery,
        SearchQuery searchQuery)
        {
            PagingQuery = pagingQuery;
            FilterQuery = filterQuery;
            SearchQuery = searchQuery;
        }

        public PagingQuery PagingQuery { get; set; }

        public FilterQuery FilterQuery { get; set; }

        public SearchQuery SearchQuery { get; set; }
    }
}
