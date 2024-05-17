using HtmxorTodoApp.Client.Pages;
using HtmxorTodoApp.Components;
using HtmxorTodoApp.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Database>(opt => {
    opt.UseSqlite("Data Source=app.db");
});

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddHtmx(htmx =>
    {
        // 💡: I like this way of config
    })
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();
app.UseHtmxAntiforgery();

app.MapRazorComponents<App>()
    // 💡: The need to pass in app is strange
    .AddHtmxorComponentEndpoints(app)
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(HtmxorTodoApp.Client._Imports).Assembly);

app.Run();