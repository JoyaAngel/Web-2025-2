using FarmaciaApp.Models;
using Microsoft.AspNetCore.Identity;

namespace FarmaciaApp.Data
{
    public static class SeedUsersRoles
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<FarmaciaUser>>();

            // Creamos estos roles por defecto
            string[] roles = new[] { "Administrador", "Cliente" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                    await roleManager.CreateAsync(new IdentityRole(role));
            }

            // Crear usuario administrador por defecto
            string adminEmail = "admin@farmacia.com";
            string password = "Admin123UmDelta!";

            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                var user = new FarmaciaUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    Nombre = "Admin",
                    Apellido = "Principal",
                    FechaRegistro = DateTime.Now
                };

                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(user, "Administrador");
            }
        }
    }
}
