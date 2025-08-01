using PlanillaUnicaApi.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;


namespace PlanillaUnicaApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class Referencia2Controller : Controller
	{
		private readonly IRepositorioReferencia2 repositorioReferencia2;

		/// <summary>
		/// Constructor del controlador de referencias 2
		/// </summary>
		/// <param name="repositorioReferencia2"></param>
		public Referencia2Controller(IRepositorioReferencia2 repositorioReferencia2)
		{
			this.repositorioReferencia2 = repositorioReferencia2;
		}

		[HttpGet]
		[Route("GetAllReferencia2")]
		public IResult GetAllReferencia2()
		{
			var referencias2 = repositorioReferencia2.GetAllReferencia2();
			if (referencias2 == null) return Results.NotFound();
			return Results.Ok(referencias2);

		}
	}
}
