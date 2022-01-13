using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Buecherapp.Models;

/// initialize Database

namespace Buecherapp
{
    public class AppDbInitializer
    {
        //private readonly RoleManager<IdentityRole> roleManager;
        private readonly ILogger<AppDbInitializer> logger;
        private readonly DataContext context;

        public AppDbInitializer(ILogger<AppDbInitializer> logger, DataContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        // migrate to the latest version of the database
        public void UpdateDb()
        {
            context.Database.Migrate();
        }
    }
}