using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Upravuvanje.Data;
using Upravuvanje.Models;

[assembly: HostingStartup(typeof(Upravuvanje.Areas.Identity.IdentityHostingStartup))]
namespace Upravuvanje.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<UpravuvanjeContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("UpravuvanjeContext")));
            });
        }
    }
}