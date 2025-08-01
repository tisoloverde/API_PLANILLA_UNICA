using PlanillaUnicaApi.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace PlanillaUnicaApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TipoPersonalOfertadoController : Controller
	{
		private readonly IRepositorioTipoPersonalOfertado repositorioTipoPersonalOfertado;

		/// <summary>
		/// Constructor del controlador de tipos de personal ofertado
		/// </summary>
		/// <param name="repositorioTipoPersonalOfertado"></param>
		public TipoPersonalOfertadoController(IRepositorioTipoPersonalOfertado repositorioTipoPersonalOfertado)
		{
			this.repositorioTipoPersonalOfertado = repositorioTipoPersonalOfertado;
		}

		[HttpGet]
		[Route("GetAllTipoPersonalOfertado")]
		public IResult GetAllTipoPersonalOfertado()
		{
			var tipoPersonalOfertado = repositorioTipoPersonalOfertado.GetAllTipoPersonalOfertado();
			if (tipoPersonalOfertado == null) return Results.NotFound();
			return Results.Ok(tipoPersonalOfertado);

		}
	}
}
