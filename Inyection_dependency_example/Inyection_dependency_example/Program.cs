using Inyection_dependency_example.Implementation;
using Inyection_dependency_example.Interface;
using Inyection_dependency_example.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

#if DEBUG
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionLocal")));
#endif

#if RELEASE
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionProductionEnvironment")));
#endif

builder.Services.AddAutoMapper(cfg => { }, typeof(AutoMapperProfiles).Assembly);
builder.Services.AddScoped<IBookAPI, BookAPI>();
builder.Services.AddScoped<IPerson, PersonAPI>();
builder.Services.AddScoped<IBookShelfAPI, BookShelfAPI>();
builder.Services.AddScoped<IBookStore, BookStoreAPI>();
builder.Services.AddScoped<IProduct, ProductAPI>();
builder.Services.AddScoped<ICategoryAPI, CategoryAPI>();
builder.Services.AddScoped<IOrder, OrderAPI>();


builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAuthentication();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.MapScalar();


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.MapOpenApi();
app.MapScalarApiReference();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
;
//app.UseSwaggerUI(options => { options.SwaggerEndpoint("/openapi/v1.json", "OpenApi"); });
//}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseRouting();

app.Run();
