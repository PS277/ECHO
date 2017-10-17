using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Raven.Client.Documents;

namespace Necro
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;
        public IConfiguration Configuration { get; }
        public static IDocumentStore Store
        {
            get => InitStore.Value;
            set => Store = InitStore.Value;
        }

        static Lazy<IDocumentStore> InitStore = new Lazy<IDocumentStore>(new DocumentStore()
        {
            Database = "Test",
            Urls = new string[] { "http://localhost:8080" }
        }.Initialize());

        public void ConfigureServices(IServiceCollection Services)
        {
            Services.AddMvc();
        }

        public void Configure(IApplicationBuilder App, IHostingEnvironment Env)
        {
            if (Env.IsDevelopment())
                App.UseDeveloperExceptionPage();
            App.UseMvc();
        }
    }
}