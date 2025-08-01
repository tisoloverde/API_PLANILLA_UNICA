using PlanillaUnicaApi.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace PlanillaUnicaApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ExpatriadoController : Controller
	{
		private readonly IRepositorioExpatriado repositorioExpatriado;

		/// <summary>
		/// Constructor del controlador de tipos expatriado
		/// </summary>
		/// <param name="repositorioExpatriado"></param>
		public ExpatriadoController(IRepositorioExpatriado repositorioExpatriado)
		{
			this.repositorioExpatriado = repositorioExpatriado;
		}

		[HttpGet]
		[Route("GetAllExpatriado")]
		public IResult GetAllExpatriado()
		{
			var expatriados = repositorioExpatriado.GetAllExpatriado();
			if (expatriados == null) return Results.NotFound();
			return Results.Ok(expatriados);

		}
	}
}
