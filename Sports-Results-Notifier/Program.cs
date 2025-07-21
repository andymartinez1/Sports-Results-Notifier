using Microsoft.Extensions.DependencyInjection;
using Sports_Results_Notifier.Controllers;
using Sports_Results_Notifier.Services;
using Sports_Results_Notifier.Views;

// Configure the DI container and register dependencies
var services = new ServiceCollection();

services.AddScoped<IScraperService, ScraperService>();
services.AddScoped<ScraperController>();
services.AddScoped<Menu>();

// Build the service provider
var serviceProvider = services.BuildServiceProvider();

// Run the application
var menu = serviceProvider.GetRequiredService<Menu>();
menu.MainMenu();

// Dispose of the service provider
serviceProvider.Dispose();
