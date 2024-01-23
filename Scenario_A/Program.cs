using Scenario_A.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddSingleton<Database>();
builder.Services.AddSingleton<Setup>();

var app = builder.Build();
/*
 * Run migration
 */


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MapGet("/migrate", (Setup setup) =>
{
    setup.MigrateDatabase();
});

app.MapGet("/reset", (Setup setup) =>
{
    setup.ResetDatabase();
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
