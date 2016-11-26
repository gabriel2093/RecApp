using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecApp_2.Models
{
    // Puede agregar datos del perfil del usuario agregando más propiedades a la clase ApplicationUser. Para más información, visite http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        [NotMapped]
        [ForeignKey("Roles")]
        public string RoleId { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("DefaultConnection", throwIfV1Schema: false)
        {

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<RecApp_2.Models.Record> Records { get; set; }

        public System.Data.Entity.DbSet<RecApp_2.Models.Tratamiento> Tratamientoes { get; set; }

        public System.Data.Entity.DbSet<RecApp_2.Models.TratamientoPaciente> TratamientoPacientes { get; set; }

        public System.Data.Entity.DbSet<RecApp_2.Models.PaymentDetails> PaymentDetails { get; set; }

        //public System.Data.Entity.DbSet<RecApp_2.Models.ApplicationUser> ApplicationUsers { get; set; }

        //public System.Data.Entity.DbSet<RecApp_2.Models.ApplicationUser> ApplicationUsers { get; set; }

        //public System.Data.Entity.DbSet<RecApp_2.Models.ApplicationUser> ApplicationUsers { get; set; }

        //public System.Data.Entity.DbSet<RecApp_2.Models.Record> Records { get; set; }

        //public System.Data.Entity.DbSet<RecApp_2.Models.ApplicationUser> ApplicationUsers { get; set; }

        //public DbSet<ApplicationUser> ApplicationUsers { get; set; }


    }
}