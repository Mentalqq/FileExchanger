using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Microsoft.AspNet.Identity;
using FinalTaskTry5.BLL.Services;
using FinalTaskTry5.BLL.Interfaces;

[assembly: OwinStartup(typeof(FinalTaskTry5.App_Start.Startup))]

namespace FinalTaskTry5.App_Start
{
    public class Startup
    {
        IServiceCreator serviceCreator = new ServiceCreator();
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(CreateGuestService);
            app.CreatePerOwinContext(CreateUserService);
            app.CreatePerOwinContext(CreateAdminService);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }

        private IGuestService CreateGuestService()
        {
            return serviceCreator.CreateGuestService("DefaultConnection");
        }
        private IUserService CreateUserService()
        {
            return serviceCreator.CreateUserService("DefaultConnection");
        }

        private IAdminService CreateAdminService()
        {
            return serviceCreator.CreateAdminService("DefaultConnection");
        }
    }
}