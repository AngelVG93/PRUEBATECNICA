using Core.Entities;
using Core.Interfaces.Repository;
using Core.Interfaces.Services;
using Core.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infraestructure.Filters;
using Infraestructure.Repositories;
using Infraestructure.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Persistence.ContextDB;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("CadenaConexion");

builder.Services.AddDbContext<pruebatecnicaDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); //Lee todos los profile de toda la solucion;
builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(FilterExceptions));
    options.Filters.Add(typeof(ActionsApiFilter));
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Configuration JWT
var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]));
builder.Services.AddAuthentication(x => {
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = key,
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});
#endregion

#region Confoguracion de validaciones 
builder.Services.AddScoped<IValidator<Product>, ProductValidator>();
builder.Services.AddScoped<IValidator<OrderProduct>, OrderProductValidator>();
builder.Services.AddScoped<IValidator<Order>, OrderValidator>();
builder.Services.AddScoped<IValidator<Permissions>, PermissionsValidator>();
builder.Services.AddScoped<IValidator<RoleUser>, RoleUserValidator>();
builder.Services.AddScoped<IValidator<Role>, RoleValidator>();
builder.Services.AddScoped<IValidator<UserOrder>, UserOrderValidator>();
builder.Services.AddScoped<IValidator<User>, UserValidator>();
builder.Services.AddScoped<IValidator<Login>, LoginValidator>();
builder.Services.AddScoped<IValidator<RolesServices>, RolesServicesValidator>();
builder.Services.AddScoped<IValidator<PermissRolesServices>, PermissRolesServicesValidator>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
#endregion

#region Configuracion de inyeccion de dependencias 
builder.Services.AddScoped<IAdminInterfaces, AdminInterfaces>();

builder.Services.AddTransient<IBaseService<Product>, ProductService>();
builder.Services.AddTransient<IProductService, ProductService>();

builder.Services.AddTransient<IBaseService<OrderProduct>, OrderProductService>();
builder.Services.AddTransient<IOrderProductService, OrderProductService>();

builder.Services.AddTransient<IBaseService<Order>, OrderService>();
builder.Services.AddTransient<IOrderService, OrderService>();

builder.Services.AddTransient<IBaseService<Permissions>, PermissionsService>();
builder.Services.AddTransient<IPermissionsService, PermissionsService>();

builder.Services.AddTransient<IBaseService<Role>, RoleServer>();
builder.Services.AddTransient<IRoleService, RoleServer>();

builder.Services.AddTransient<IBaseService<RoleUser>, RoleUserService>();
builder.Services.AddTransient<IRoleUserService, RoleUserService>();

builder.Services.AddTransient<IBaseService<UserOrder>, UserOrderService>();
builder.Services.AddTransient<IUserOrderService, UserOrderService>();

builder.Services.AddTransient<IBaseService<User>, UserService>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddTransient<IBaseService<Login>, LoginServer>();
builder.Services.AddTransient<ILoginServer, LoginServer>();

builder.Services.AddTransient<IBaseService<Service>, ServiceService>();
builder.Services.AddTransient<IServiceService, ServiceService>();

builder.Services.AddTransient<IBaseService<PermissRolesServices>, PermissRolesServicesService>();
builder.Services.AddTransient<IPermissRolesServicesService, PermissRolesServicesService>();

builder.Services.AddTransient<IBaseService<RolesServices>, RolesServicesService>();
builder.Services.AddTransient<IPermissRolesServicesService, PermissRolesServicesService>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
