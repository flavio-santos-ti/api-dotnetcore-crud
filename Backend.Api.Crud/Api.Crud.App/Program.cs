using Api.Crud.Business.Interfaces;
using Api.Crud.Business.Services;
using Api.Crud.Infra.Data.Context;
using Api.Crud.Infra.Data.Interfaces;
using Api.Crud.Infra.Data.Repositories;
using Api.Crud.Infra.Data.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Api.Crud.Business.Validator.Usuario;
using Api.Crud.Business.Validator.Login;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// adicionado --------------------------------

builder.Services.AddDbContext<DatabaseContext>(opts => opts.UseNpgsql(builder.Configuration.GetConnectionString("PgSqlConnection")));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPessoaService, PessoaService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();
builder.Services.AddScoped<ILoginService, LoginService>();


AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true); // Habilitar DateTime.Now comum 

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddApiVersioning(p =>
{
    p.DefaultApiVersion = new ApiVersion(1, 0);
    p.ReportApiVersions = true;
    p.AssumeDefaultVersionWhenUnspecified = true;
});

builder.Services.AddValidatorsFromAssemblyContaining<CreateUsuarioValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateUsuarioValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<RequestLoginValidator>();


string tokenSecret = builder.Configuration.GetSection("TokenConfiguration").GetValue<string>("TokenSecret");
var secretKey = Encoding.UTF8.GetBytes(tokenSecret);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(secretKey),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
// .AddJwtBearer(options =>
// {
//     options.TokenValidationParameters = new TokenValidationParameters
//     {
//         ValidateIssuer = true,
//         ValidateAudience = true,
//         ValidateIssuerSigningKey = true,
//         IssuerSigningKey = new SymmetricSecurityKey(secretKey)
//     };

//     options.Events = new JwtBearerEvents
//     {
//         OnAuthenticationFailed = context =>
//         {
//             if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
//             {
//                 context.Response.Headers.Add("Token-Expired", "true");
//             }
//             return Task.CompletedTask;
//         }
//     };
// });

//--------------------------------------------

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
