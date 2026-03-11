using EducationAssignmentPortal.Components;
using EducationAssignmentPortal.Data;
using EducationAssignmentPortal.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;



var builder = WebApplication.CreateBuilder(args); // application configuratiob object

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<UserService>(); // instance per user session
builder.Services.AddScoped<AssignmentService>();
builder.Services.AddScoped<CourseService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddAuthorizationCore();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

//builder.Services.AddDbContext<AppDBContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddDbContextFactory<AppDBContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build(); //time to create the actual web server

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
