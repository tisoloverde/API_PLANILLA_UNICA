using Microsoft.OpenApi.Models;
using PlanillaUnicaApi.Repository;
using PlanillaUnicaApi.Repository.IRepository;
using PlanillaUnicaApi.Models;
using PlanillaUnicaApi.Models.Dto;

namespace PlanillaUnicaApi
{
	/// <summary>
	/// 
	/// </summary>
	public class Startup
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="configuration"></param>
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		/// <summary>
		/// 
		/// </summary>
		public IConfiguration Configuration { get; }

		/// <summary>
		/// This method gets called by the runtime. Use this method to add services to the container.
		/// </summary>
		/// <param name="services"></param>
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddScoped<IRepositorioAfp, RepositorioAfp>();
			services.AddScoped<IRepositorioEstadoCivil, RepositorioEstadoCivil>();
			services.AddScoped<IRepositorioExpatriado, RepositorioExpatriado>();
			services.AddScoped<IRepositorioJubilado, RepositorioJubilado>();
			services.AddScoped<IRepositorioLicenciaConducir, RepositorioLicenciaConducir>();
			services.AddScoped<IRepositorioNivelEstudio, RepositorioNivelEstudio>();
			services.AddScoped<IRepositorioNivelOcupacional, RepositorioNivelOcupacional>();
			services.AddScoped<IRepositorioProfesion, RepositorioProfesion>();
			services.AddScoped<IRepositorioSalud, RepositorioSalud>();
			services.AddScoped<IRepositorioSistemaPension, RepositorioSistemaPension>();
			services.AddScoped<IRepositorioSituacion, RepositorioSituacion>();
			services.AddScoped<IRepositorioTipoAbono, RepositorioTipoAbono>();
			services.AddScoped<IRepositorioTipoContrato, RepositorioTipoContrato>();
			services.AddScoped<IRepositorioVinculoContacto, RepositorioVinculoContacto>();
			services.AddScoped<IRepositorioColaborador, RepositorioColaborador>();
			services.AddScoped<IRepositorioDotacion, RepositorioDotacion>();
			services.AddScoped<IRepositorioTipoPersonalOfertado, RepositorioTipoPersonalOfertado>();
			services.AddScoped<IRepositorioFamilia, RepositorioFamilia>();
			services.AddScoped<IRepositorioCargoGenerico, RepositorioCargoGenerico>();
			services.AddScoped<IRepositorioClasificacion, RepositorioClasificacion>();
			services.AddScoped<IRepositorioReferencia1, RepositorioReferencia1>();
			services.AddScoped<IRepositorioReferencia2, RepositorioReferencia2>();
			
			services.AddAutoMapper(configuration =>
			{
				configuration.CreateMap<Rh_DotacionDto, Rh_Dotacion>();
				configuration.CreateMap<Rh_Dotacion, Rh_DotacionDto>();



			}, typeof(Startup));

			services.AddControllers();
			AddSwagger(services);

		}

		private void AddSwagger(IServiceCollection services)
		{
			services.AddSwaggerGen(options =>
			{
				var groupname = "v1";

				options.SwaggerDoc(groupname, new OpenApiInfo
				{
					Title = $"API Soloverde Planilla Única,  {groupname}",
					Version = groupname,
					Description = "API Soloverde Planilla Única",
					Contact = new OpenApiContact
					{
						Name = "Soloverde",
						Email = string.Empty,
						Url = new Uri("http://www.soloverde.cl/"),
					}
				});
			});
		}

		/// <summary>
		/// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		/// </summary>
		/// <param name="app"></param>
		/// <param name="env"></param>
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Soloverde Planilla Única");
			});

			app.UseRouting();

			//app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

		}
	}
}
