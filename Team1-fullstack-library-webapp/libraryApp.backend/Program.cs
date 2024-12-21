using libraryApp.backend.Entity;
using libraryApp.backend.Repository.Abstract;
using libraryApp.backend.Repository.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);
// Add CORS services to the container
builder.Services.AddCors(options =>
{
    options.AddPolicy("TestOrigin",
        policy =>
        {
            policy.WithOrigins("http://localhost:5173") // Replace with your frontend domain
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});
builder.Services.AddControllers();
builder.Services.AddDbContext<LibraryDbContext>(options =>
{
    var connStr = builder.Configuration["ConnectionStrings:DefaultConnection"];
    options.UseNpgsql(connStr);
});

// Add services to the container.
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateIssuerSigningKey = false,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration.GetSection("AppSettings:Secret").Value ?? "")),
        ValidateLifetime = true,
        RoleClaimType = "roleName"

    };
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddScoped<IBookAuthorRepository, EfBookAuthorRepository>();
builder.Services.AddScoped<IBookPublishRequestRepository, EfBookPublishRequestRepository>();
builder.Services.AddScoped<IBookRepository, EfBookRepository>();
builder.Services.AddScoped<ILoanRequestRepository, EfLoanRequestRepository>();
builder.Services.AddScoped<IMessageRepository, EfMessageRepository>();
builder.Services.AddScoped<IPageRepository, EfPageRepository>();
builder.Services.AddScoped<IRoleRepository, EfRoleRepository>();
builder.Services.AddScoped<IUserRepository, EfUserRepository>();
builder.Services.AddScoped<IRegisterRequestRepository, EfRegisterRequestRepository>();
builder.Services.AddScoped<IPunishRepository, EfPunishRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("TestOrigin");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
