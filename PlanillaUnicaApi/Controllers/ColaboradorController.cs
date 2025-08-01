using PlanillaUnicaApi.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace PlanillaUnicaApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ColaboradorController : Controller
	{
		private readonly IRepositorioColaborador repositorioColaborador;

		/// <summary>
		/// Constructor del controlador de clientes
		/// </summary>
		/// <param name="repositorioCliente"></param>
		public ColaboradorController(IRepositorioColaborador repositorioColaborador)
		{
			this.repositorioColaborador = repositorioColaborador;
		}

		[HttpGet]
		[Route("GetAllColaboradores")]
		public IResult GetAllColaboradores()
		{
			var respuesta = repositorioColaborador.ObtieneColaboradorLista();
			if (respuesta == null) return Results.NotFound();
			return Results.Ok(respuesta);

		}

		[HttpGet]
		[Route("GetColaboradorId")]
		public IResult GetColaboradorId(decimal colaboradorId)
		{
			var respuesta = repositorioColaborador.ObtieneColaboradorListaId(colaboradorId);
			if (respuesta == null) return Results.NotFound();
			return Results.Ok(respuesta);

		}
	}
}
