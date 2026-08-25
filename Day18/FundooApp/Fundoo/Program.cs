using Business.Interface;
using Business.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Repository.Context;
using Repository.Interface;
using Repository.Service;
using System.Text;
using Microsoft.OpenApi;
using RabbitMQ;
using Fundoo.Services;
using RabbitMQ.Interface;
using RabbitMQ.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<INoteRepository, NoteRepository>();
builder.Services.AddScoped<INoteService, NoteService>();
builder.Services.AddScoped<ILabelRepository, LabelRepository>();
builder.Services.AddScoped<ILabelService, LabelService>();
builder.Services.AddSingleton<IRabbitMQProducer, RabbitMQProducer>();
builder.Services.AddHostedService<ReminderBackgroundService>();
builder.Services.AddSingleton<IEmailService, EmailService>();

builder.Services.AddSingleton<IRabbitMQProducer, RabbitMQProducer>();
builder.Services.AddSingleton<IRabbitMQConsumer, RabbitMQConsumer>();

builder.Services.AddHostedService<ReminderBackgroundService>();
builder.Services.AddHostedService<RabbitMQConsumerService>();
builder.Services.AddHostedService<ReminderBackgroundService>();
builder.Services.AddHostedService<RabbitMQConsumerService>();

var jwtSettings = builder.Configuration.GetSection("Jwt");

var jwtKey = jwtSettings["Key"]
    ?? throw new InvalidOperationException("JWT key is missing.");

var jwtIssuer = jwtSettings["Issuer"]
    ?? throw new InvalidOperationException("JWT issuer is missing.");

var jwtAudience = jwtSettings["Audience"]
    ?? throw new InvalidOperationException("JWT audience is missing.");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = jwtIssuer,
            ValidAudience = jwtAudience,

            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtKey)
            )
        };
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter your JWT token."
    });

    options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("Bearer", document)] = []
    });
});
var app = builder.Build();

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