using Microsoft.EntityFrameworkCore;
using MyApi.Data;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            });
        });

        services.AddControllers();
        // Other service configurations
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Deliveries/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();

        app.UseCors(); // Enable CORS

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }


    //public void ConfigureServices(IServiceCollection services)
    //{
    //    services.AddCors(options =>
    //    {
    //        options.AddPolicy("CorsPolicy",
    //            builder => builder.AllowAnyOrigin()
    //                              .AllowAnyMethod()
    //                              .AllowAnyHeader());
    //    });

    //    services.AddControllers();
    //}

    //public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    //{
    //    if (env.IsDevelopment())
    //    {
    //        app.UseDeveloperExceptionPage();
    //    }

    //    app.UseHttpsRedirection();
    //    app.UseRouting();
    //    app.UseCors("CorsPolicy");
    //    app.UseAuthorization();

    //    app.UseEndpoints(endpoints =>
    //    {
    //        endpoints.MapControllers();
    //    });
    //}


    //public void ConfigureServices(IServiceCollection services)
    //{
    //    services.AddControllers();
    //    services.AddDbContext<MyApiContext>(options =>
    //        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
    //}

    //public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    //{
    //    if (env.IsDevelopment())
    //    {
    //        app.UseDeveloperExceptionPage();
    //    }

    //    app.UseHttpsRedirection();
    //    app.UseRouting();
    //    app.UseAuthorization();
    //    app.UseEndpoints(endpoints =>
    //    {
    //        endpoints.MapControllers();
    //    });
    //}
}
