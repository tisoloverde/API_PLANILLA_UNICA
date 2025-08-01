using PlanillaUnicaApi.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace PlanillaUnicaApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EstadoCivilController : Controller
	{
		private readonly IRepositorioEstadoCivil repositorioEstadoCivil;

		/// <summary>
		/// Constructor del controlador de estado civil
		/// </summary>
		/// <param name="repositorioEstadoCivil"></param>
		public EstadoCivilController(IRepositorioEstadoCivil repositorioEstadoCivil)
		{
			this.repositorioEstadoCivil = repositorioEstadoCivil;
		}

		[HttpGet]
		[Route("GetAllEstadoCivil")]
		public IResult GetAllEstadoCivil()
		{
			var estadosCivil = repositorioEstadoCivil.GetAllEstadoCivil();
			if (estadosCivil == null) return Results.NotFound();
			return Results.Ok(estadosCivil);

		}
	}
}
