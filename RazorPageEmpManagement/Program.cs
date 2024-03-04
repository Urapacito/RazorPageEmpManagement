using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service.DepartmentService;
using Service.EmployeeService;
using Service.RoleService;
using Service.SimpleSecurityService;
using Service.TeamsService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<ITeamsService, TeamsService>();
builder.Services.AddScoped<ISimpleSecurityService, SimpleSecurityService>();

// Add session services
builder.Services.AddDistributedMemoryCache(); // Required to use session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = System.TimeSpan.FromMinutes(30); // Session timeout
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Add authentication services
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Index"; // Set the login path
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Use authentication after 'UseRouting' and before 'UseAuthorization'

app.UseAuthorization();

app.UseSession(); // Use session after 'UseAuthorization' and before 'UseEndpoints'

app.MapRazorPages();

app.Run();
