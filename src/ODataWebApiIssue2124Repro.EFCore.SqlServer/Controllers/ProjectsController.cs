using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Query;
using Microsoft.AspNetCore.Mvc;
using NS.Data;
using NS.Models;
using System.Linq;

namespace NS.Controllers
{
    public class ProjectsController : ODataController
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

        [EnableQuery]
        public SingleResult<Project> Get([FromODataUri] int key)
        {
            return SingleResult.Create(_db.Projects.Where(d => d.Id.Equals(key)));
        }
    }
}
