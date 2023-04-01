using API.Queries;
using API.Queries.Ideas;

namespace API.DTOs.Idea.GetListIdeas
{
    public class GetListIdeasRequest
    {
        public GetListIdeasRequest(
        PagingQuery pagingQuery,
        SearchQuery searchQuery,
        IdeaFilter ideaFilter)
        {
            PagingQuery = pagingQuery;
            SearchQuery = searchQuery;
            IdeaFilter = ideaFilter;
        }

        public PagingQuery PagingQuery { get; }

        public SearchQuery SearchQuery { get; }

        public IdeaFilter IdeaFilter { get; }
    }
}
