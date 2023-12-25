using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PhonesShope.Services;
using PhonesShope;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IProductService, ClientServices>();
builder.Services.AddScoped<ICategoryService, ClientServices>();
builder.Services.AddScoped<MessageDialogService>();

builder.Services.AddSyncfusionBlazor();
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NAaF5cWWJCf1FpR2tGfV5yd0VAalxTTndbUj0eQnxTdEZiW31ccXNQQWNbV0N2XA==");


await builder.Build().RunAsync();
