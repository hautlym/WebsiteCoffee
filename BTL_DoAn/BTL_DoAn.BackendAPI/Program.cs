using BTL_DoAn.Application.Catalog.Carts;
using BTL_DoAn.Application.Catalog.Categories;
using BTL_DoAn.Application.Catalog.Common;
using BTL_DoAn.Application.Catalog.Contacts;
using BTL_DoAn.Application.Catalog.Orders;
using BTL_DoAn.Application.Catalog.Policies;
using BTL_DoAn.Application.Catalog.Products;
using BTL_DoAn.Application.Catalog.System;
using BTL_DoAn.Application.Catalog.System.Dtos;
using BTL_DoAn.Application.Catalog.Validate;
using BTL_DoAn.Data.EF;
using BTL_DoAn.Data.Entities;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddControllersWithViews()
                .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddDbContext<BTL_DoAnDbContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("BTL_DoAn_Database")));
builder.Services.AddIdentity<AppUser, AppRoles>().AddEntityFrameworkStores<BTL_DoAnDbContext>().AddDefaultTokenProviders();

builder.Services.AddTransient<IStorageService, FileStorageService>();
builder.Services.AddTransient<IPublicProductService, PublicProductService>();
builder.Services.AddTransient<IManageProductService, ManageProductService>();
builder.Services.AddTransient<IManageCategory, ManageCategory>();
//builder.Services.AddTransient<UserManager<AppUser>, UserManager<AppUser>>();
//builder.Services.AddTransient<SignInManager<AppUser>, SignInManager<AppUser>>();
//builder.Services.AddTransient<RoleManager<AppUser>, RoleManager<AppUser>>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IManageContact, ManageContact>();
builder.Services.AddTransient<IManageCart, ManagerCart>();
builder.Services.AddTransient<IRolesService, RolesService>();
builder.Services.AddTransient<IManageOrder, ManageOrder>();
builder.Services.AddTransient<IManagePolicy, ManagePolicy>();
builder.Services.AddTransient<IValidator<LoginRequest>, LoginRequestValidator>();

builder.Services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LoginRequestValidator>());
string issuer = "https://hello.api.com";
string signingKey = "123456789987654321";
byte[] signingKeyBytes = System.Text.Encoding.UTF8.GetBytes(signingKey);
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
           .AddJwtBearer(options =>
           {
               options.RequireHttpsMetadata = false;
               options.SaveToken = true;
               options.TokenValidationParameters = new TokenValidationParameters()
               {
                   ValidateIssuer = true,
                   ValidIssuer = issuer,
                   ValidateAudience = true,
                   ValidAudience = issuer,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
                   ClockSkew = System.TimeSpan.Zero,
                   IssuerSigningKey = new SymmetricSecurityKey(signingKeyBytes)
               };
           });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();

app.MapControllers();

app.Run();
