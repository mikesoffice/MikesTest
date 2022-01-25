using MediatR;
using MRT.Application;
using MRT.UI.Filters;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddTransient<ScenariosPageFilter>();
builder.Services.AddMediatR(typeof(EntryPoint).GetTypeInfo().Assembly);

builder.Services.AddRazorPages(options =>
{
}).AddMvcOptions(options =>
{
    options.Filters.Add<ScenariosPageFilter>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
