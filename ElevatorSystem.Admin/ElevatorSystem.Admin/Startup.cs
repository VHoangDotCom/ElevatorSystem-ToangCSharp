using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Owin;
using System.Text;

[assembly: OwinStartupAttribute(typeof(ElevatorSystem.Admin.Startup))]
namespace ElevatorSystem.Admin
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.UseJwtBearerAuthentication(
             new JwtBearerAuthenticationOptions
             {
                 AuthenticationMode = AuthenticationMode.Active,
                 TokenValidationParameters = new TokenValidationParameters()
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateIssuerSigningKey = true,
                     ValidIssuer = "isser", //some string, normally web url,  
                      ValidAudience = "nguoitao",
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("401b09eab3c013d4ca54922b"))
                 }
             });
        }
    }
}
