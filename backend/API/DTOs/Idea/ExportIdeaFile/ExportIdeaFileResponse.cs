using API.DTOs.Idea.GetIdea;
using Common.DataType;

namespace API.DTOs.Idea.ExportIdeaFile
{
    public class ExportIdeaFileResponse
    {
        public ExportIdeaFileResponse(DataList<GetIdeaResponse> dataList)
        {
            Result = dataList;
        }

        public DataList<GetIdeaResponse> Result { get; set; }
    }
}
