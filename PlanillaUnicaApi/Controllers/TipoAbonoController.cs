using PlanillaUnicaApi.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace PlanillaUnicaApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TipoAbonoController : Controller
	{
		private readonly IRepositorioTipoAbono repositorioTipoAbono;

		/// <summary>
		/// Constructor del controlador de tipos de abono
		/// </summary>
		/// <param name="repositorioTipoAbono"></param>
		public TipoAbonoController(IRepositorioTipoAbono repositorioTipoAbono)
		{
			this.repositorioTipoAbono = repositorioTipoAbono;
		}

		[HttpGet]
		[Route("GetAllTipoAbono")]
		public IResult GetAllTipoAbono()
		{
			var tipoAbono = repositorioTipoAbono.GetAllTipoAbono();
			if (tipoAbono == null) return Results.NotFound();
			return Results.Ok(tipoAbono);

		}
	}
}
