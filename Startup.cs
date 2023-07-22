using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

using ODataBridge.Models;
using ODataBridge.Data;


namespace ODataBridge
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddOData(opt =>
            {
                opt.AddRouteComponents("odata", GetEdmModel()).Count().Filter().Expand().Select().OrderBy().SetMaxTop(5);
                opt.RouteOptions.EnableControllerNameCaseInsensitive = true;
            });

            services.AddDbContext<MyDbContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static IEdmModel GetEdmModel()
        {
            var odataBuilder = new ODataConventionModelBuilder();
            odataBuilder.EntitySet<Period>("Periods");
            odataBuilder.EntitySet<Product>("Products");
            odataBuilder.EntitySet<Region>("Regions");
            odataBuilder.EntitySet<Sales>("Sales");

            return odataBuilder.GetEdmModel();
        }
    }
}
