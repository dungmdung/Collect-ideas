using API.Queries.Ideas;
using API.Queries;

namespace API.DTOs.Idea.ExportIdeaFile
{
    public class ExportIdeaFileRequest
    {
        public ExportIdeaFileRequest(IdeaFilter ideaFilter)
        {
            IdeaFilter = ideaFilter;
        }

        public IdeaFilter IdeaFilter { get; set; }
    }
}
