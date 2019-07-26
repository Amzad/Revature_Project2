using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Revature_Project2.Areas.Identity.IdentityHostingStartup))]
namespace Revature_Project2.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });

            /*builder.ConfigureServices((context, services) => {
                services.AddIdentity<ApplicationUser, IdentityRole>()
                     .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultUI(UIFramework.Bootstrap4);
            });*/
        }
    }
}