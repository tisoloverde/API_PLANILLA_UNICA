using PlanillaUnicaApi.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace PlanillaUnicaApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ClasificacionController : Controller
	{
		private readonly IRepositorioClasificacion repositorioClasificacion;

		/// <summary>
		/// Constructor del controlador de clasificaciones
		/// </summary>
		/// <param name="repositorioClasificacion"></param>
		public ClasificacionController(IRepositorioClasificacion repositorioClasificacion)
		{
			this.repositorioClasificacion = repositorioClasificacion;
		}

		[HttpGet]
		[Route("GetAllClasificacion")]
		public IResult GetAllClasificacion()
		{
			var clasificaciones = repositorioClasificacion.GetAllClasificacion();
			if (clasificaciones == null) return Results.NotFound();
			return Results.Ok(clasificaciones);

		}
	}
}
