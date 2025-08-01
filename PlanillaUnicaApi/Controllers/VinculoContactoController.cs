using PlanillaUnicaApi.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace PlanillaUnicaApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class VinculoContactoController : Controller
	{
		private readonly IRepositorioVinculoContacto repositorioVinculoContacto;

		/// <summary>
		/// Constructor del controlador de vínculos contacto
		/// </summary>
		/// <param name="repositorioTipoContrato"></param>
		public VinculoContactoController(IRepositorioVinculoContacto repositorioVinculoContacto)
		{
			this.repositorioVinculoContacto = repositorioVinculoContacto;
		}

		[HttpGet]
		[Route("GetAllVinculoContacto")]
		public IResult GetAllVinculoContacto()
		{
			var vinculoContacto = repositorioVinculoContacto.GetAllVinculoContacto();
			if (vinculoContacto == null) return Results.NotFound();
			return Results.Ok(vinculoContacto);

		}
	}
}
