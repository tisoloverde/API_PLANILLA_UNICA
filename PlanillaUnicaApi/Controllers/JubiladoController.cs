using PlanillaUnicaApi.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace PlanillaUnicaApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class JubiladoController : Controller
	{
		private readonly IRepositorioJubilado repositorioJubilado;

		/// <summary>
		/// Constructor del controlador de tipos jubilados
		/// </summary>
		/// <param name="repositorioJubilado"></param>
		public JubiladoController(IRepositorioJubilado repositorioJubilado)
		{
			this.repositorioJubilado = repositorioJubilado;
		}

		[HttpGet]
		[Route("GetAllJubilado")]
		public IResult GetAllJubilado()
		{
			var jubilados = repositorioJubilado.GetAllJubilado();
			if (jubilados == null) return Results.NotFound();
			return Results.Ok(jubilados);

		}
	}
}
