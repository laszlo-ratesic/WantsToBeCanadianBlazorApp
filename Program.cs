using Microsoft.EntityFrameworkCore;
using WantsToBeCanadianBlazorApp.Components;
using WantsToBeCanadianBlazorApp.Data;
using WantsToBeCanadianBlazorApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// This is me registering the DbContext with in-memory database
// It will be different for you since you're using a real SQL db
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("WantsToBeCanadianDatabase"));

// THIS IS IMPORTANT
// This is me registering the ProductsService with the DI container
builder.Services.AddScoped<ProductsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
    
app.Run();
