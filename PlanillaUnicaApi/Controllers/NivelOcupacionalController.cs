using PlanillaUnicaApi.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace PlanillaUnicaApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NivelOcupacionalController : Controller
	{
		private readonly IRepositorioNivelOcupacional repositorioNivelOcupacional;

		/// <summary>
		/// Constructor del controlador de niveles de ocupacion
		/// </summary>
		/// <param name="repositorioNivelEstudio"></param>
		public NivelOcupacionalController(IRepositorioNivelOcupacional repositorioNivelOcupacional)
		{
			this.repositorioNivelOcupacional = repositorioNivelOcupacional;
		}

		[HttpGet]
		[Route("GetAllNivelOcupacional")]
		public IResult GetAllNivelOcupacional()
		{
			var nivelesOcupacional = repositorioNivelOcupacional.GetAllNivelOcupacional();
			if (nivelesOcupacional == null) return Results.NotFound();
			return Results.Ok(nivelesOcupacional);

		}
	}
}
