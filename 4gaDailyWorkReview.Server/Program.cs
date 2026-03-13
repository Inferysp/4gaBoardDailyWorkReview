using _4gaDailyWorkReview.Server.Data;
using _4gaDailyWorkReview.Server.Handlers;
using _4gaDailyWorkReview.Server.Queries;
using _4gaDailyWorkReview.Server.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Konfiguracja DB
builder.Services.AddDbContext<DailyWorkContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IDbConnection>(sp =>
    new NpgsqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddScoped<IProjectReadRepository, ProjectReadRepository>();

//MediatR < 
//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
//MediatR 11.*
builder.Services.AddMediatR(typeof(Program).Assembly);
builder.Services.AddMediatR(typeof(GetProjectsQueryHandler).Assembly);
builder.Services.AddMediatR(typeof(GetProjectQueryHandler).Assembly);
//MediatR 12.*
//builder.Services.AddMediatR(cfg => cfg.RequestExceptionActionProcessorStrategy(AppDomain.CurrentDomain.GetAssemblies())); 

builder.Services.AddControllers();
// 1. Poprawiony CORS - dodaj oba warianty (http i https)
builder.Services.AddCors(options => {
    options.AddPolicy("AllowReact", policy => {
        policy.WithOrigins("https://localhost:58282", "http://localhost:58282")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();
app.MapControllers();
app.UseCors("AllowReact");

//Rejestracja Grup i Tras Cards minimal API
var dailyWorkReviewItems = app.MapGroup("/cards");

dailyWorkReviewItems.MapGet("/", GetUserCards);
dailyWorkReviewItems.MapGet("/{id:long}", GetCard);
dailyWorkReviewItems.MapGet("/day/{dt}", GetCardsForTheDay);

//GET : cards
static async Task<IResult> GetUserCards([FromServices] DailyWorkContext db)
{
    var cards = await db.Cards
        .Where(t => t.CreatedById == 1639186154697786370)
        .Select(x => new { x.Name, x.Description, x.UpdatedById})
        .ToListAsync();
    return TypedResults.Ok(cards);
}

// GET : cards/{id}
static async Task<IResult> GetCard(long id, [FromServices] DailyWorkContext db)
{
    var card = await db.Cards.FindAsync(id);
    return card is not null ? TypedResults.Ok(card) : TypedResults.NotFound();
}

// GET : cards/day/{id}
static async Task<IResult> GetCardsForTheDay(DateTime dt, [FromServices] DailyWorkContext ctx)
{
    var day = DateOnly.FromDateTime(dt);
    var date = day.ToDateTime(TimeOnly.MinValue, DateTimeKind.Utc); //without kind, because we want to compare only date part
    var cards = await ctx.Cards
        .Where(e => (e.UpdatedAt.HasValue && e.UpdatedAt.Value.Date == date.Date)
                    ||(e.CreatedAt.HasValue && e.CreatedAt.Value.Date == date.Date))
        .Select(x => new { x.Id, x.Name, x.Description, x.UpdatedById })
        .ToListAsync();
    return TypedResults.Ok(cards);
}   

//CQRS MediatR Minimal API
app.MapGet("minimalapi/projects", async ([FromServices] IMediator mediator) =>
{
    var query = new GetProjectsQuery();
    var projects = await mediator.Send(query);
    return projects is not null ? Results.Ok(projects) : Results.NotFound();
});

//CQRS MediatR Full API
app.MapGet("minimalapi/project/{id:long}", async (long id, IMediator mediator) =>
{
    var q = new GetProjectQuery(id);
    var project = await mediator.Send(q);
    return project is null ? Results.NotFound() : Results.Ok(project);
});


app.Run();
