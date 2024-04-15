using LR11.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<UniqueUsersCountFilter>(provider =>
{
    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "unique_users.txt");
    return new UniqueUsersCountFilter(filePath);
});
builder.Services.AddScoped<MethodLoggingFilter>(provider =>
{
    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "method_logging.txt");
    return new MethodLoggingFilter(filePath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
