using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
 
var builder = WebApplication.CreateBuilder(args);
 
// внедрение зависимости Entity Framework
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlite("Data Source=usercacheapp.db"));
// внедрение зависимости UserService
builder.Services.AddTransient<UserService>();
// добавление кэширования
builder.Services.AddStackExchangeRedisCache(options => {
    options.Configuration = "localhost";
    options.InstanceName = "local";
});

builder.Services.AddHealthChecks();

var app = builder.Build();
 
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}
public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) => 
        Database.EnsureCreated();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // инициализация БД начальными данными
        modelBuilder.Entity<User>().HasData(
                new User { Nick = "svpra", Name = "Andrew", Email = "me@svpra.ml" },
                new User { Nick = "giantdick228", Name = "Pizdec Marshallovich", Email = "gde.za4em@gmail.com" },
                new User { Nick = "omygodami", Name = "Ami", Email = "omygodami@gmail.com" }
        );
    }
}
public class UserService
{
    ApplicationContext db;
    IDistributedCache cache;
    public UserService(ApplicationContext context, IDistributedCache distributedCache)
    {
        db = context;
        cache = distributedCache;
    }
    public async Task<User?> GetUser(int id)
    {
        User? user = null;
        // пытаемся получить данные из кэша по id
        var userString = await cache.GetStringAsync(id.ToString());
        //десериализируем из строки в объект User
        if (userString != null) user = JsonSerializer.Deserialize<User>(userString);
 
        // если данные не найдены в кэше
        if (user == null)
        {
            // обращаемся к базе данных
            user = await db.Users.FindAsync(id);
            // если пользователь найден, то добавляем в кэш
            if (user != null)
            {
                Console.WriteLine($"{user.Name} извлечен из базы данных");
                // сериализуем данные в строку в формате json
                userString = JsonSerializer.Serialize(user);
                // сохраняем строковое представление объекта в формате json в кэш на 2 минуты
                await cache.SetStringAsync(user.Id.ToString(), userString, new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(2)
                });
            }
        }
        else
        {
            Console.WriteLine($"{user.Name} извлечен из кэша");
        }
        return user;
    }
    app.MapGet("/", () => return View(Home));
    app.MapGet("/user/{User.Nick}", async (int id, UserService userService) =>
    {
        User? user = await userService.GetUser(Nick);
        if (user != null) return View(User)";
        return "User not found";
    });
    app.MapGet("/create", () => return View(Create));
    app.MapHealthChecks("/healthcheck");

    app.Run();
}
