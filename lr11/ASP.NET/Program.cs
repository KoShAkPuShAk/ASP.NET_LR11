var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc(options =>
{
    options.Filters.Add(typeof(LogActionFilter));
    options.Filters.Add(typeof(UniqueUsersFilter) );
});
var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "",
    defaults: new { controller = "Home", action = "Index" });

app.Run();