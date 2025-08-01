using PlanillaUnicaApi.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;


namespace PlanillaUnicaApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class Referencia1Controller : Controller
	{
		private readonly IRepositorioReferencia1 repositorioReferencia1;

		/// <summary>
		/// Constructor del controlador de referencias 1
		/// </summary>
		/// <param name="repositorioReferencia1"></param>
		public Referencia1Controller(IRepositorioReferencia1 repositorioReferencia1)
		{
			this.repositorioReferencia1 = repositorioReferencia1;
		}

		[HttpGet]
		[Route("GetAllReferencia1")]
		public IResult GetAllReferencia1()
		{
			var referencias1 = repositorioReferencia1.GetAllReferencia1();
			if (referencias1 == null) return Results.NotFound();
			return Results.Ok(referencias1);

		}
	}
}
