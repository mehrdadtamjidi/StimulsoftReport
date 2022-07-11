using StimulsoftReport.Utilities.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();


#region Add DbContext
builder.Services.AddApplicationDbContext(builder.Configuration);
#endregion

#region Register Service
builder.Services.RegisterServices();
#endregion

#region Add StimulsoftReport license
var licenseFile = System.IO.Path.Combine(builder.Environment.WebRootPath, @"Reports\license", "license.key");
Stimulsoft.Base.StiLicense.LoadFromFile(licenseFile);
#endregion

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

//app.MapRazorPages();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Viewer}/{action=Index}/{id?}");
});
app.Run();
