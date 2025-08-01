using PlanillaUnicaApi.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace PlanillaUnicaApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AfpController : Controller
	{
		private readonly IRepositorioAfp repositorioAfp;

		/// <summary>
		/// Constructor del controlador de afp
		/// </summary>
		/// <param name="repositorioAfp"></param>
		public AfpController(IRepositorioAfp repositorioAfp)
		{
			this.repositorioAfp = repositorioAfp;
		}

		[HttpGet]
		[Route("GetAllAfp")]
		public IResult GetAllAfp()
		{
			var afp = repositorioAfp.GetAllAfp();
			if (afp == null) return Results.NotFound();
			return Results.Ok(afp);

		}

	}
}
