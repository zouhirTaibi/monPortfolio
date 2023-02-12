using Core.Interfaces;
using Infrastructure;
using Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web
{
    public class Startup
    {
        //datacontext apres  dependecny injection
        //DI c'est un design pattern 
        //DI c'est une methode d'ecriture le code
        //DI c'est que une classe se base sur une autre 
        //on utilise IConfiguration pour on se connecte au base de donnees
        public readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            //cette methode s'appelle independency injection dans le constructeur
            this.configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<DataContext>(options =>
            {
                //a partir de variable configuration qu'on deja cree,je suis 
                //capable d'acceder au fichier de configuration de connection situe dans
                //le fichier appseting.json
                options.UseSqlServer(configuration.GetConnectionString("MyPortfolioDB"));
            });
            //dependencies of IUnitOfWork
            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //pour utiliser les dossiers 
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
            //  / localhost
            endpoints.MapControllerRoute(
                
                "defaultRoute",
                    "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
