using Microsoft.EntityFrameworkCore;
using TableFlow.Data;
using System.Text.Json.Serialization;
using Scalar.AspNetCore;
using TableFlow.Repositories;
using TableFlow.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// REPOS & SERVICES
builder.Services.AddScoped<IBillItemLogRepository, BillItemLogRepository>();
builder.Services.AddScoped<IBillItemLogService, BillItemLogService>();

builder.Services.AddScoped<IBillItemsRepository, BillItemsRepository>();
builder.Services.AddScoped<IBillItemsService, BillItemsService>();

builder.Services.AddScoped<IBillRepository, BillRepository>();
builder.Services.AddScoped<IBillService, BillService>();

builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddScoped<ICategoriesService, CategoriesServices>();

builder.Services.AddScoped<IOrganisationRepository, OrganisationRepository>();
builder.Services.AddScoped<IOrganisationService, OrganisationService>();

builder.Services.AddScoped<IPermissionModelRepository, PermissionModelRepository>();
builder.Services.AddScoped<IPermissionModelService, PermissionModelService>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IRoomService, RoomService>();

builder.Services.AddScoped<ITableRepository, TableRepository>();
builder.Services.AddScoped<ITableService, TableService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

//CORS FOR NEXT.JS
builder.Services.AddCors(option =>
{
    option.AddPolicy("AllowNextJS", builder =>
    {
        builder.WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapScalarApiReference();
}

app.UseCors("AllowNextJS");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();