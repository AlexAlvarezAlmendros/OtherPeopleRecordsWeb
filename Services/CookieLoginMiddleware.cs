using Microsoft.AspNetCore.Identity;

namespace OtherPeopleRecordsWeb.Services
{
    public class CookieLoginMiddleware
    {
        private readonly RequestDelegate _next;

        public CookieLoginMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, SignInManager<IdentityUser> signInManager)
        {
            if (context.Request.Path.StartsWithSegments("/login-middleware"))
            {
                string email = context.Request.Query["email"];
                var user = await signInManager.UserManager.FindByEmailAsync(email);
                if (user != null)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    context.Response.Redirect("/");
                    return;
                }
            }
            else if (context.Request.Path.StartsWithSegments("/logout"))
            {
                // Lógica para manejar el logout
                await signInManager.SignOutAsync();
                context.Response.Redirect("/"); // Redirige al usuario a la página de inicio después del logout
                return;
            }

            await _next(context);
        }
    }
}
