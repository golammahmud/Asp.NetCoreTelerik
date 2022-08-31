using asp.netcoreTelerikGrid.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
var builder = WebApplication.CreateBuilder(args);
var connection = builder.Configuration.GetConnectionString("DBConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connection));
// Add framework services.
builder.Services
	.AddRazorPages()
	// Maintain property names during serialization. See:
	// https://github.com/aspnet/Announcements/issues/194
	.AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver());
// Add Kendo UI services to the services container
builder.Services.AddKendo();

// Add services to the container.

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

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
