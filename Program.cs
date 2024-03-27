using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
using MudBlazor.Services;
using OtherPeopleRecordsWeb.Areas.Identity;
using OtherPeopleRecordsWeb.Data;
using OtherPeopleRecordsWeb.Entities;
using OtherPeopleRecordsWeb.Global;
using OtherPeopleRecordsWeb.Services;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddHttpClient();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
builder.Services.AddSingleton<Global>();
builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopCenter;
    config.SnackbarConfiguration.PreventDuplicates = true;
    config.SnackbarConfiguration.NewestOnTop = true;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.VisibleStateDuration = 30000;
    config.SnackbarConfiguration.HideTransitionDuration = 500;
    config.SnackbarConfiguration.ShowTransitionDuration = 500;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
});
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

    // Asegúrate de que el rol existe, si no, créalo
    if (!await roleManager.RoleExistsAsync("Admin"))
    {
        await roleManager.CreateAsync(new IdentityRole("Admin"));
    }
    if (!await roleManager.RoleExistsAsync("Manager"))
    {
        await roleManager.CreateAsync(new IdentityRole("Manager"));
    }
    if (!await roleManager.RoleExistsAsync("Artist"))
    {
        await roleManager.CreateAsync(new IdentityRole("Artist"));
    }
    if (!await roleManager.RoleExistsAsync("User"))
    {
        await roleManager.CreateAsync(new IdentityRole("User"));
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


#region MINIMAL API
app.MapPost("/cards", async (Card card, ApplicationDbContext context) =>
{
	try
	{
		context.Cards.Add(card);
		await context.SaveChangesAsync();
		return Results.Created($"/cards/{card.Id}", card);
	}
	catch (Exception ex)
	{
		return Results.Problem(ex.Message);
	}
});

app.MapGet("/cards", async (ApplicationDbContext context) => {
	return await context.Cards.AsNoTracking().ToListAsync();
});

app.MapPut("/cards/{id}", async (Guid id, Card updateCard, ApplicationDbContext context) =>
{
	var existingCard = await context.Cards.FindAsync(id);
	if (existingCard == null) return Results.NotFound();

	existingCard.Title = updateCard.Title ?? existingCard.Title;
	existingCard.Subtitle = updateCard.Subtitle ?? existingCard.Subtitle;
	existingCard.SpotifyLink = updateCard.SpotifyLink ?? existingCard.SpotifyLink;
	existingCard.YoutubeLink = updateCard.YoutubeLink ?? existingCard.YoutubeLink;
	existingCard.AppleMusicLink = updateCard.AppleMusicLink ?? existingCard.AppleMusicLink;
	existingCard.InstagramLink = updateCard.InstagramLink ?? existingCard.InstagramLink;
	existingCard.SoundCloudLink = updateCard.SoundCloudLink ?? existingCard.SoundCloudLink;
	existingCard.BeatStarsLink = updateCard.BeatStarsLink ?? existingCard.BeatStarsLink;
	existingCard.TwitterLink = updateCard.TwitterLink ?? existingCard.TwitterLink;
	existingCard.Ubicacion = updateCard.Ubicacion ?? existingCard.Ubicacion;
	existingCard.IMG = updateCard.IMG ?? existingCard.IMG;
	existingCard.VIDEO = updateCard.VIDEO ?? existingCard.VIDEO;
	existingCard.cardType = updateCard.cardType;
	existingCard.date = updateCard.date;

	await context.SaveChangesAsync();

	return Results.NoContent();
});

app.MapDelete("/cards/{id}", async (int id, ApplicationDbContext context) =>
{
	var tmpcard = await context.Cards.FindAsync(id);
	if (tmpcard == null) return Results.NotFound();

	context.Cards.Remove(tmpcard);
	await context.SaveChangesAsync();

	return Results.Ok(tmpcard);
});



#endregion







app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<CookieLoginMiddleware>();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapBlazorHub();
    endpoints.MapFallbackToPage("/_Host");
});

app.Run();




