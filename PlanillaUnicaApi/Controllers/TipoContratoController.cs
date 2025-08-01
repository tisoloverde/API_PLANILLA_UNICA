using PlanillaUnicaApi.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace PlanillaUnicaApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TipoContratoController : Controller
	{
		private readonly IRepositorioTipoContrato repositorioTipoContrato;

		/// <summary>
		/// Constructor del controlador de tipos de contrato
		/// </summary>
		/// <param name="repositorioTipoContrato"></param>
		public TipoContratoController(IRepositorioTipoContrato repositorioTipoContrato)
		{
			this.repositorioTipoContrato = repositorioTipoContrato;
		}

		[HttpGet]
		[Route("GetAllTipoContrato")]
		public IResult GetAllTipoContrato()
		{
			var tipoContrato = repositorioTipoContrato.GetAllTipoContrato();
			if (tipoContrato == null) return Results.NotFound();
			return Results.Ok(tipoContrato);

		}
	}
}
