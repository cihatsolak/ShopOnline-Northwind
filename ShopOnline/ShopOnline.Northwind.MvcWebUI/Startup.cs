using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopOnline.Core.Settings;
using ShopOnline.Northwind.Business.Concrete;
using ShopOnline.Northwind.Business.Interfaces;
using ShopOnline.Northwind.DataAccess.Concrete.EntityFrameworkCore.Repositories;
using ShopOnline.Northwind.DataAccess.Interfaces;
using ShopOnline.Northwind.MvcWebUI.Middlewares;
using ShopOnline.Northwind.MvcWebUI.Services;

namespace ShopOnline.Northwind.MvcWebUI
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession();
            services.AddHttpContextAccessor();

            services.Configure<ProductControllerSettings>(Configuration.GetSection(nameof(ProductControllerSettings)));

            services.AddScoped<IProductDal, EfProductRepository>();
            services.AddScoped<IProductService, ProductManager>();

            services.AddScoped<ICategoryDal, EfCategoryRepository>();
            services.AddScoped<ICategoryService, CategoryManager>();

            services.AddSingleton<ICartSessionService, CartSessionManager>();
            services.AddSingleton<ICartService, CartManager>();

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseNodeModules(env.ContentRootPath);

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
