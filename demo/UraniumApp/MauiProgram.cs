﻿//using CommunityToolkit.Maui;
using DotNurse.Injector;
using Mopups.Hosting;
using UraniumApp.Pages;
using UraniumUI;

namespace UraniumApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            //.UseMauiCommunityToolkit()
            .UseUraniumUI()
            .UseUraniumUIMaterial()
            .UseUraniumUIBlurs()
            .ConfigureMopups()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddMaterialIconFonts();
            });

        var thisAssembly = typeof(MauiProgram).Assembly;

        builder.Services.AddServicesFrom(
            type => typeof(Page).IsAssignableFrom(type),
            ServiceLifetime.Transient,
            options => options.Assembly = thisAssembly)
        .AddServicesByAttributes(assembly: thisAssembly);

        //builder.Services.AddCommunityToolkitDialogs();
        builder.Services.AddMopupsDialogs();

        return builder.Build();
    }
}
