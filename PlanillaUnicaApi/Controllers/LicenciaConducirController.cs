using PlanillaUnicaApi.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace PlanillaUnicaApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LicenciaConducirController : Controller
	{
		private readonly IRepositorioLicenciaConducir repositorioLicenciaConducir;

		/// <summary>
		/// Constructor del controlador de licencia de conducir
		/// </summary>
		/// <param name="repositorioLicenciaConducir"></param>
		public LicenciaConducirController(IRepositorioLicenciaConducir repositorioLicenciaConducir)
		{
			this.repositorioLicenciaConducir = repositorioLicenciaConducir;
		}

		[HttpGet]
		[Route("GetAllLicenciaConducir")]
		public IResult GetAllLicenciaConducir()
		{
			var licenciasConducir = repositorioLicenciaConducir.GetAllLicenciaConducir();
			if (licenciasConducir == null) return Results.NotFound();
			return Results.Ok(licenciasConducir);

		}
	}
}
