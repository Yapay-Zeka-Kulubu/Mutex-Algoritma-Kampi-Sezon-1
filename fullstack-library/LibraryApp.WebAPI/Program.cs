using LibraryApp.Data.Entity;
using LibraryApp.Data.Abstract;
using LibraryApp.Data.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
    options.UseNpgsql(connStr, b => b.MigrationsAssembly("fullstack-library"));
});

builder.Services.AddScoped<IBookAuthorRepository, EfBookAuthorRepository>();
builder.Services.AddScoped<IBookBorrowActivityRepository, EfBookBorrowActivityRepository>();
builder.Services.AddScoped<IBookRepository, EfBookRepository>();
builder.Services.AddScoped<IPageRepository, EfPageRepository>();
builder.Services.AddScoped<IRoleRepository, EfRoleRepository>();
builder.Services.AddScoped<IUserRepository, EfUserRepository>();
builder.Services.AddScoped<IMessageRepository, EfMessageRepository>();
builder.Services.AddScoped<IBookPublishRequestRepository, EfBookPublishRequestRepository>();

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
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration.GetSection("AppSettings:Secret").Value ?? "")),
        ValidateLifetime = true,
        RoleClaimType = "roleName"
    };
});

builder.Services.AddAuthorization(opt =>
{
    opt.AddPolicy("ManagerPolicy", policy => policy.RequireRole("manager"));
    opt.AddPolicy("AuthorPolicy", policy => policy.RequireRole("author"));
    opt.AddPolicy("StaffOrManagerPolicy", policy => policy.RequireRole("staff", "manager"));
    opt.AddPolicy("MemberOrHigherPolicy", policy => policy.RequireRole("member", "author", "staff", "manager"));
});

var app = builder.Build();
app.UseRouting();
app.UseCors("TestOrigin");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();