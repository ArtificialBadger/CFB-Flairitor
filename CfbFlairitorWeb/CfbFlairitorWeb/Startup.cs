using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SimpleInjector;
using CfbFlairitorWeb.Abstractions;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;

namespace CfbFlairitorWeb
{
	public class Startup
	{
		private Container container = new Container();

		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
				.AddEnvironmentVariables();
			Configuration = builder.Build();
		}

		public IConfigurationRoot Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			// ASP.NET default stuff here
			services.AddMvc();

			services.AddSingleton<IControllerActivator>(new SimpleInjectorControllerActivator(container));

			services.AddSingleton<IViewComponentActivator>(new SimpleInjectorViewComponentActivator(container));

			services.UseSimpleInjectorAspNetRequestScoping(container);

		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			InitializeContainer(app);

			loggerFactory.AddConsole(Configuration.GetSection("Logging"));
			loggerFactory.AddDebug();

			container.Verify();

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseBrowserLink();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseStaticFiles();

			app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=Home}/{action=Index}/{id?}");
			});
		}

		private void InitializeContainer(IApplicationBuilder app)
		{
			container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

			// Add application presentation components:
			container.RegisterMvcControllers(app);
			container.RegisterMvcViewComponents(app);

			// Add application services. For instance:
			container.Register<IService, ConcreteService>();
		}
	}
}
