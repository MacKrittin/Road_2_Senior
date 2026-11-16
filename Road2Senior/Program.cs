using Road2Senior.Models;
using Road2Senior.Services.Implementations;
using Road2Senior.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// 1. Register Email Sender implementations
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddScoped<FakeEmailSender>();
}
else
{
    builder.Services.AddScoped<SmtpEmailSender>();
}

// 2. Register IEmailSender using Factory Lambda
builder.Services.AddScoped<IEmailSender>(sp =>
{
    if (builder.Environment.IsDevelopment())
    {
        return sp.GetRequiredService<FakeEmailSender>();
    }

    return sp.GetRequiredService<SmtpEmailSender>();
});

// 3. Register NotificationService
builder.Services.AddScoped<LoggingEmailSender>();

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
