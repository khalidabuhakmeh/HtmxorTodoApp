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

        // have to enable this to allow out of band updates
        htmx.UseTemplateFragments = true;
    });

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
app.UseHtmxAntiforgery();

app.MapRazorComponents<App>()
    // 💡: The need to pass in app is strange
    // This is because Htmxor is stealing the discovered set of components
    // from Blazor so the logic does not have to be reimplemented,
    // but at the same time need access to the `app` to register additional
    // endpoints in the app. This is a bit of a hack, but it works.
    .AddHtmxorComponentEndpoints(app);

app.Run();