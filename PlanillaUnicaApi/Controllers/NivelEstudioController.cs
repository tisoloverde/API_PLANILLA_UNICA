using PlanillaUnicaApi.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace PlanillaUnicaApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NivelEstudioController : Controller
	{
		private readonly IRepositorioNivelEstudio repositorioNivelEstudio;

		/// <summary>
		/// Constructor del controlador de niveles de estudio
		/// </summary>
		/// <param name="repositorioNivelEstudio"></param>
		public NivelEstudioController(IRepositorioNivelEstudio repositorioNivelEstudio)
		{
			this.repositorioNivelEstudio = repositorioNivelEstudio;
		}

		[HttpGet]
		[Route("GetAllNivelEstudio")]
		public IResult GetAllNivelEstudio()
		{
			var nivelesEstudio = repositorioNivelEstudio.GetAllNivelEstudio();
			if (nivelesEstudio == null) return Results.NotFound();
			return Results.Ok(nivelesEstudio);

		}
	}
}
