using PlanillaUnicaApi.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace PlanillaUnicaApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SaludController : Controller
	{
		private readonly IRepositorioSalud repositorioSalud;

		/// <summary>
		/// Constructor del controlador de salud
		/// </summary>
		/// <param name="repositorioSalud"></param>
		public SaludController(IRepositorioSalud repositorioSalud)
		{
			this.repositorioSalud = repositorioSalud;
		}

		[HttpGet]
		[Route("GetAllSalud")]
		public IResult GetAllSalud()
		{
			var salud = repositorioSalud.GetAllSalud();
			if (salud == null) return Results.NotFound();
			return Results.Ok(salud);

		}
	}
}
