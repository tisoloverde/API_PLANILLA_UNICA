using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlanillaUnicaApi.Repository.IRepository;
using PlanillaUnicaApi.Models.Dto;
using PlanillaUnicaApi.Models;
using PlanillaUnicaApi.Repository;

namespace PlanillaUnicaApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AsistenciaController : Controller
	{
		private readonly IRepositorioAsistencia repositorioAsistencia;
		private readonly IMapper mapper;

		/// <summary>
		/// Constructor del controlador de asistencia
		/// </summary>
		/// <param name="repositorioDotacion"></param>
		public AsistenciaController(IRepositorioAsistencia repositorioAsistencia, IMapper mapper)
		{
			this.repositorioAsistencia = repositorioAsistencia;
			this.mapper = mapper;
		}

		[HttpGet]
		[Route("GetSemanasAnoLista")]
		public IResult GetSemanasAnoLista(int ano)
		{
			var respuesta = repositorioAsistencia.ObtieneSemanasAno(ano);
			if (respuesta == null) return Results.NotFound();
			return Results.Ok(respuesta);

		}

		[HttpGet]
		[Route("GetAsistenciaConceptos")]
		public IResult GetAsistenciaConceptos()
		{
			var respuesta = repositorioAsistencia.GetAllAsistenciaConceptos();
			if (respuesta == null) return Results.NotFound();
			return Results.Ok(respuesta);

		}

		[HttpGet]
		[Route("GetAsistenciaLista")]
		public IResult GetAsistenciaLista(decimal centroCosto, int periodo, string fechaInicio, string fechaTermino)
		{
			var respuesta = repositorioAsistencia.ObtieneAsistenciaCentroPeriodoSemana(centroCosto, periodo, fechaInicio, fechaTermino);
			if (respuesta == null) return Results.NotFound();
			return Results.Ok(respuesta);

		}
	}
}
