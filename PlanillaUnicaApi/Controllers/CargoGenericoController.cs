using PlanillaUnicaApi.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace PlanillaUnicaApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CargoGenericoController : Controller
	{
		private readonly IRepositorioCargoGenerico repositorioCargoGenerico;

		/// <summary>
		/// Constructor del controlador de cargos genericos
		/// </summary>
		/// <param name="repositorioCargoGenerico"></param>
		public CargoGenericoController(IRepositorioCargoGenerico repositorioCargoGenerico)
		{
			this.repositorioCargoGenerico = repositorioCargoGenerico;
		}

		[HttpGet]
		[Route("GetAllCargoGenerico")]
		public IResult GetAllCargoGenerico()
		{
			var cargosGenerico = repositorioCargoGenerico.GetAllCargoGenerico();
			if (cargosGenerico == null) return Results.NotFound();
			return Results.Ok(cargosGenerico);

		}
	}
}
