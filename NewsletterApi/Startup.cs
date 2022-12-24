using System.Net.Mail;
using System.Net;
using NewsletterApi.Domain.Services;
using NewsletterApi.Domain.Persistence;
using Microsoft.EntityFrameworkCore;
using NewsletterApi.Domain.Context;
using NewsletterApi.Domain.Providers;

namespace NewsletterApi;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        // Add Entity Framework Core
        services.AddDbContext<NewsletterDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

        // Add the newsletter service and repository
        services.AddScoped<INewsletterService, NewsletterService>();
        services.AddScoped<INewsletterRepository, NewsletterRepository>();

        // Add the email sender
        services.AddScoped<IEmailSender, EmailSender>();
        services.AddSingleton(new SmtpClient
        {
            Host = Configuration["SMTP:Server"],
            Port = int.Parse(Configuration["SMTP:Port"]),
            Credentials = new NetworkCredential(Configuration["SMTP:Username"], Configuration["SMTP:Password"])
        });

        // Add the newsletter controller
        services.AddControllers();

        services.AddSwaggerGen(c =>
        {

        });

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blog API");
            c.DisplayRequestDuration();
        });

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();
        app.UseStaticFiles();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
