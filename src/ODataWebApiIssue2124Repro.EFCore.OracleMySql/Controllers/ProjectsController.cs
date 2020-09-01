using Microsoft.AspNet.OData;
using NS.Data;
using NS.Models;
using System.Linq;

namespace NS.Controllers
{
    public class ProjectsController
    {
        private readonly ReproDbContext _db;

        public ProjectsController(ReproDbContext db)
        {
            _db = db;
        }

        [EnableQuery]
        public IQueryable<Project> Get()
        {
            return _db.Projects;
        }
    }
}
