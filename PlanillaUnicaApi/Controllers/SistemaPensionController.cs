using PlanillaUnicaApi.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace PlanillaUnicaApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SistemaPensionController : Controller
	{
		private readonly IRepositorioSistemaPension repositorioSistemaPension;

		/// <summary>
		/// Constructor del controlador de sistemas de pensión
		/// </summary>
		/// <param name="repositorioSistemaPension"></param>
		public SistemaPensionController(IRepositorioSistemaPension repositorioSistemaPension)
		{
			this.repositorioSistemaPension = repositorioSistemaPension;
		}

		[HttpGet]
		[Route("GetAllSistemaPension")]
		public IResult GetAllSistemaPension()
		{
			var sistemaPension = repositorioSistemaPension.GetAllSistemaPension();
			if (sistemaPension == null) return Results.NotFound();
			return Results.Ok(sistemaPension);

		}
	}
}
