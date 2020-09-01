using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;
using NS.Models;

namespace NS
{
    static class ConfigurationHelper
    {
        internal static IEdmModel GetEdmModel()
        {
            var modelBuilder = new ODataConventionModelBuilder();

            modelBuilder.EntitySet<Project>("Projects");
            modelBuilder.EntitySet<Task>("Tasks");
            modelBuilder.EntitySet<Employee>("Employees");

            return modelBuilder.GetEdmModel();
        }
    }
}
