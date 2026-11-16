using Microsoft.Extensions.DependencyInjection;
using Road2Senior.Models;
using Road2Senior.Services.Implementations;
using Road2Senior.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// 1. Register actual implementations
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddScoped<FakeEmailSender>();
}
else
{
    builder.Services.AddScoped<SmtpEmailSender>();
}

// 2. Register Logging Decorator
builder.Services.AddScoped<LoggingEmailSender>();

// 3. Register IEmailSender using Factory Lambda
builder.Services.AddScoped<IEmailSender>(sp =>
{
    IEmailSender actualSender;

    if (builder.Environment.IsDevelopment())
    {
        actualSender = sp.GetRequiredService<FakeEmailSender>();
    }
    else
    {
        actualSender = sp.GetRequiredService<SmtpEmailSender>();
    }

    var logger = sp.GetRequiredService<ILogger<LoggingEmailSender>>();

    return new LoggingEmailSender(
    logger: logger,
    emailSender: actualSender
);
});

builder.Services.AddTransient<OperationTracker>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Order}/{action=Index}/{id?}");

app.Run();
