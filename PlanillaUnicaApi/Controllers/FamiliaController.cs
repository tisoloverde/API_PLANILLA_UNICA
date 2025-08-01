using PlanillaUnicaApi.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace PlanillaUnicaApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FamiliaController : Controller
	{
		private readonly IRepositorioFamilia repositorioFamilia;

		/// <summary>
		/// Constructor del controlador de familias
		/// </summary>
		/// <param name="repositorioFamilia"></param>
		public FamiliaController(IRepositorioFamilia repositorioFamilia)
		{
			this.repositorioFamilia = repositorioFamilia;
		}

		[HttpGet]
		[Route("GetAllFamilia")]
		public IResult GetAllFamilia()
		{
			var familias = repositorioFamilia.GetAllFamilia();
			if (familias == null) return Results.NotFound();
			return Results.Ok(familias);

		}
	}
}
