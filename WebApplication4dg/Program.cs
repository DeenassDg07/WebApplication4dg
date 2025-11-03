using MyMediator.Extension;
using MyMediator.Interfaces;
using MyMediator.Types;
using System.Reflection;
using WebApplication4dg.DB;
using WebApplication4dg.sqrs.Registration;
using WebApplication4dg.Validators;
using WebApplication4dg.Validators.Behavior;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddDbContext<MagazinEptContext>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMediatorHandlers(Assembly.GetExecutingAssembly());
builder.Services.AddSingleton<IMediator, Mediator>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidatorBehavior<,>));

builder.Services.AddScoped<Mediator>();
builder.Services.AddMediatorHandlers(Assembly.GetExecutingAssembly());

// Сами валидаторы
builder.Services.AddScoped<MyMediator.Types.Mediator>();
builder.Services.AddMediatorHandlers(Assembly.GetExecutingAssembly());
builder.Services.AddTransient<IValidator<Register>, RegisterValidators>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
