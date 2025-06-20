using IThubSAT.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(connectionString));

// builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<XlsxProcessingService>(sp =>
{
    var dbContext = sp.CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();
    return new (dbContext);
});
builder.Services.AddScoped(sp =>
{
    var dbContext = sp.CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();
    return new SurveyService(dbContext);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.MapGet("Workload/DownloadTemplate", (XlsxProcessingService service) => service.DownloadTemplate());
// для этого зачем вообще путь отдельный?
//app.MapGet("Workload/Import", (ImportService service) => service.Import());

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
