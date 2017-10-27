using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Raven.Client.Documents;

namespace Pokedex
{
    public class Startup
    {
        public static IDocumentStore Store => InitStore.Value;
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration _Configuration) => Configuration = _Configuration;

        static Lazy<IDocumentStore> InitStore = new Lazy<IDocumentStore>(new DocumentStore()
        {
            Database = "Pokedex",
            Urls = new string[] { "http://localhost:8080" }
        }.Initialize());

        public void ConfigureServices(IServiceCollection Services)
        {
            Services.AddMvc();
        }

        public void Configure(IApplicationBuilder AppBuilder, IHostingEnvironment HostingEnvironment)
        {
            if (HostingEnvironment.IsDevelopment())
            {
                AppBuilder.UseDeveloperExceptionPage();
            }

            AppBuilder.UseMvc();
        }
    }
}
