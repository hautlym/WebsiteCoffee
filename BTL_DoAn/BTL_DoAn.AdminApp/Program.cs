using BTL_DoAn.ApiIntegration.Service.CategoryApiClient;
using BTL_DoAn.ApiIntegration.Service.ContactApiClient;
using BTL_DoAn.ApiIntegration.Service.OrderApaiClient;
using BTL_DoAn.ApiIntegration.Service.PoliciesApiClient;
using BTL_DoAn.ApiIntegration.Service.ProductApiClient;
using BTL_DoAn.ApiIntegration.Service.RolesApiClient;
using BTL_DoAn.ApiIntegration.Service.UserApiClient;
using BTL_DoAn.Application.Catalog.Validate;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddControllers(options =>
//{
//    var jsonInputFormatter = options.InputFormatters
//        .OfType<Microsoft.AspNetCore.Mvc.Formatters.SystemTextJsonInputFormatter>()
//        .Single();
//    jsonInputFormatter.SupportedMediaTypes.Add("application/csp-report");
//}
//  );
builder.Services.AddControllersWithViews();
var mvcBuilder = builder.Services.AddRazorPages();

builder.Services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LoginRequestValidator>());
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Index/";
        options.AccessDeniedPath = "/User/Forbidden/";
    });
if (builder.Environment.IsDevelopment())
{
    mvcBuilder.AddRazorRuntimeCompilation();
}
builder.Services.AddHttpClient();
builder.Services.AddTransient<IUserApiClient, UserApiClient>();
builder.Services.AddTransient<IRoleApiClient, RoleApiClient>();
builder.Services.AddTransient<IProductApiClient, ProductApiClient>();
builder.Services.AddTransient<ICategoriesApiClient, CategoriesApiClient>();
builder.Services.AddTransient<IContactApiClient, ContactApiClient>();
builder.Services.AddTransient<IOrderApiClient, OrderApiClient>();
builder.Services.AddTransient<IPolicyApiClient, PolicyApiClient>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

}
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});
app.UseAuthentication();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
