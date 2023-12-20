using EdChannel.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using EdChannel.Models;
using EdChannel.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<ApplicationRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
    options.JsonSerializerOptions.ReferenceHandler  = ReferenceHandler.IgnoreCycles;

});
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireAdministratorRole",
         policy => policy.RequireRole("Administrator"));
});
builder.Services.AddAuthentication()
   .AddGoogle(options =>
   {
       IConfigurationSection googleAuthNSection =
       config.GetSection("Authentication:Google");
       options.ClientId = googleAuthNSection["ClientId"];
       options.ClientSecret = googleAuthNSection["ClientSecret"];
   });
//.AddFacebook(options =>
//{
//    IConfigurationSection FBAuthNSection =
//    config.GetSection("Authentication:FB");
//    options.ClientId = FBAuthNSection["ClientId"];
//    options.ClientSecret = FBAuthNSection["ClientSecret"];
//})
//.AddMicrosoftAccount(microsoftOptions =>
//{
//    microsoftOptions.ClientId = config["Authentication:Microsoft:ClientId"];
//    microsoftOptions.ClientSecret = config["Authentication:Microsoft:ClientSecret"];
//});

builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.Configure<AuthMessageSenderOptions>(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseStatusCodePages();
    app.UseStatusCodePagesWithRedirects("~/ErrorPage/{0}");
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
);
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
//using (var scopes = app.Services.CreateScope())
//{
//    var roleManager = scopes.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
//    var roles = new[] { "Admin", "Member", "User" };
//    foreach (var role in roles)
//    {
//        if (!await roleManager.RoleExistsAsync(role))
//            await roleManager.CreateAsync(new ApplicationRole(role));
//    }
//}
//using (var scopes = app.Services.CreateScope())
//{
//    var userManager = scopes.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
//    string emailAdmin = "1234@123.com";
//    string passwordAdmin = "Tu12345678@";
//    if (await userManager.FindByEmailAsync(emailAdmin) == null)
//    {
//        var user = new ApplicationUser
//        {
//            Email = emailAdmin,
//            FirstName = emailAdmin,
//            LastName = emailAdmin,
//            UserName = emailAdmin,
//            EmailConfirmed = true
//        };
//        await userManager.CreateAsync(user, passwordAdmin);
//        await userManager.AddToRoleAsync(user, "Admin");
//    }
//}
app.Run();
