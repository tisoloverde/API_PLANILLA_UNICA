using PlanillaUnicaApi.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace PlanillaUnicaApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProfesionController : Controller
	{
		private readonly IRepositorioProfesion repositorioProfesion;

		/// <summary>
		/// Constructor del controlador de profesiones
		/// </summary>
		/// <param name="repositorioProfesion"></param>
		public ProfesionController(IRepositorioProfesion repositorioProfesion)
		{
			this.repositorioProfesion = repositorioProfesion;
		}

		[HttpGet]
		[Route("GetAllProfesion")]
		public IResult GetAllProfesion()
		{
			var profesiones = repositorioProfesion.GetAllProfesion();
			if (profesiones == null) return Results.NotFound();
			return Results.Ok(profesiones);

		}
	}
}
