using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlanillaUnicaApi.Repository.IRepository;
using PlanillaUnicaApi.Models.Dto;
using PlanillaUnicaApi.Models;

namespace PlanillaUnicaApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DotacionController : Controller
	{
		private readonly IRepositorioDotacion repositorioDotacion;
		private readonly IMapper mapper;

		/// <summary>
		/// Constructor del controlador de dotacion
		/// </summary>
		/// <param name="repositorioDotacion"></param>
		public DotacionController(IRepositorioDotacion repositorioDotacion, IMapper mapper)
		{
			this.repositorioDotacion = repositorioDotacion;
			this.mapper = mapper;
		}

		[HttpGet]
		[Route("GetDotacionLista")]
		public IResult GetDotacionLista(decimal centroCosto, decimal periodo)
		{
			var respuesta = repositorioDotacion.ObtieneDotacionLista(centroCosto,periodo);
			if (respuesta == null) return Results.NotFound();
			return Results.Ok(respuesta);

		}

		/// <summary>
		/// Método que permite crear un nuevo registro de dotación 
		/// </summary>
		/// <param name="dotacionDTO"></param>
		/// <returns></returns>
		[HttpPut]
		[Route("NewDotacion")]
		public IActionResult NewDotacion([FromBody] Rh_DotacionDto dotacionDTO)
		{
			Resultado_ExecDto resultado = new Resultado_ExecDto();
			if (!ModelState.IsValid)
			{
				resultado.Estado = "ERROR";
				resultado.Mensaje = "Modelo no válido";
				return StatusCode(400, resultado);
			}
			try
			{
				//////if (usuarioRepository.UsuarioExists(usuarioDTO.Email_Usr))
				//////{
				//////    ModelState.AddModelError(string.Empty, $"ya existe un usuario con este correo {usuarioDTO.Email_Usr}");
				//////    return StatusCode(404, ModelState);
				//////}
				var dotacion = mapper.Map<Rh_Dotacion>(dotacionDTO);
				resultado = repositorioDotacion.CreateDotacion(dotacion);
				return StatusCode(200, resultado);
			}
			catch (Exception ex)
			{
				resultado.Estado = "ERROR";
				resultado.Mensaje = ex.Message;
				return StatusCode(500, resultado);
			}
		}

		/// <summary>
		/// Método que permite actualizar un registro de dotación
		/// </summary>
		/// <param name="dotacionDTO"></param>
		/// <returns></returns>
		[HttpPost]
		[Route("UpdateDotacion")]
		public IActionResult UpdateDotacion([FromBody] Rh_DotacionDto dotacionDTO)
		{
			Resultado_ExecDto resultado = new Resultado_ExecDto();
			if (!ModelState.IsValid)
			{
				resultado.Estado = "ERROR";
				resultado.Mensaje = "Modelo no válido";
				return StatusCode(400, resultado);
			}
			try
			{
				var dotacion = mapper.Map<Rh_Dotacion>(dotacionDTO);
				resultado = repositorioDotacion.ActualizaDotacion(dotacion);
				return StatusCode(200, resultado);
			}
			catch (Exception ex)
			{
				resultado.Estado = "ERROR";
				resultado.Mensaje = ex.Message;
				return StatusCode(500, resultado);
			}
		}
	}
}
