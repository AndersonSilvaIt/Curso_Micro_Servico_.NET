using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.IdentityServer.Model.Context
{
    public class PGContext : IdentityDbContext<ApplicationUser>
    {
        public PGContext()
        {

        }
        public PGContext(DbContextOptions<PGContext> options)
            : base(options) { }
    }
}
