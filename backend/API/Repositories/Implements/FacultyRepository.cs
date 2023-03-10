using API.Repositories.Interfaces;
using Data;
using Data.Entities;

namespace API.Repositories.Implements
{
    public class FacultyRepository : BaseRepository<Faculty>, IFacultyRepository
    {
        public FacultyRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
