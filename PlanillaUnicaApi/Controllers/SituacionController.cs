using PlanillaUnicaApi.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace PlanillaUnicaApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SituacionController : Controller
	{
		private readonly IRepositorioSituacion repositorioSituacion;

		/// <summary>
		/// Constructor del controlador de situaciones
		/// </summary>
		/// <param name="repositorioSituacion"></param>
		public SituacionController(IRepositorioSituacion repositorioSituacion)
		{
			this.repositorioSituacion = repositorioSituacion;
		}

		[HttpGet]
		[Route("GetAllSituacion")]
		public IResult GetAllSituacion()
		{
			var situacion = repositorioSituacion.GetAllSituacion();
			if (situacion == null) return Results.NotFound();
			return Results.Ok(situacion);

		}
	}
}
