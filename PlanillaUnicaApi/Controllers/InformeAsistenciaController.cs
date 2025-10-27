using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlanillaUnicaApi.Models.Dto;
using PlanillaUnicaApi.Models;
using PlanillaUnicaApi.Repository;
using PlanillaUnicaApi.Repository.IRepository;
using PlanillaUnicaApi.Services;
using PlanillaUnicaApi.Services;

namespace PlanillaUnicaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformeAsistenciaController : Controller
    {
        private readonly IRepositorioInformeAsistencia repositorioInformeAsistencia;
        private readonly IMapper mapper;
        private readonly IEmailService emailService;
        private readonly IExcelService excelService;
        private readonly ILogger<InformeAsistenciaController> logger;

        /// <summary>
        /// Constructor del controlador de informes de asistencia
        /// </summary>
        /// <param name="repositorioInformeAsistencia"></param>
        /// <param name="mapper"></param>
        /// <param name="emailService"></param>
        /// <param name="excelService"></param>
        /// <param name="logger"></param>
        public InformeAsistenciaController(
            IRepositorioInformeAsistencia repositorioInformeAsistencia, 
            IMapper mapper,
            IEmailService emailService,
            IExcelService excelService,
            ILogger<InformeAsistenciaController> logger)
        {
            this.repositorioInformeAsistencia = repositorioInformeAsistencia;
            this.mapper = mapper;
            this.emailService = emailService;
            this.excelService = excelService;
            this.logger = logger;
        }

        /// <summary>
		/// Método que genera informes de asistencia y los envía por correo electrónico
		/// </summary>
		/// <param name="informeAsistenciaDto"></param>
		/// <returns></returns>
		[HttpPost]
        [Route("GeneraInforme")]
        public async Task<IActionResult> GeneraInforme([FromBody] Rh_Informe_AsistenciaDto informeAsistenciaDto)
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
                var informes = mapper.Map<Rh_Informe_Asistencia>(informeAsistenciaDto);
                var attachments = new List<EmailAttachment>();
                bool hasReports = false;

                foreach (var detalle in informes.TiposInforme)
                {
                    if (detalle.TipoInforme.Equals(1)) // Horas extras 50%
                    {
                        List<Rh_Informe_Salida_He> resultados50 = repositorioInformeAsistencia.ObtieneInformeHe50(informes);
                        
                        if (resultados50?.Count > 0)
                        {
                            var excelData = excelService.GenerateExcelReport(resultados50, "HE50", informeAsistenciaDto.FechaInicio, informeAsistenciaDto.FechaTermino);
                            var fileName = $"he50_{informeAsistenciaDto.FechaInicio.Replace("/", "")}_{informeAsistenciaDto.FechaTermino.Replace("/", "")}.xlsx";
                            
                            attachments.Add(new EmailAttachment
                            {
                                Content = excelData,
                                FileName = fileName,
                                ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
                            });
                            
                            hasReports = true;
                            logger.LogInformation($"Generado informe HE50 con {resultados50.Count} registros");
                        }
                    } 
                    else if(detalle.TipoInforme.Equals(2)) // Horas extras 100%
                    {
                        List<Rh_Informe_Salida_He> resultados100 = repositorioInformeAsistencia.ObtieneInformeHe100(informes);
                        
                        if (resultados100?.Count > 0)
                        {
                            var excelData = excelService.GenerateExcelReport(resultados100, "HE100", informeAsistenciaDto.FechaInicio, informeAsistenciaDto.FechaTermino);
                            var fileName = $"he100_{informeAsistenciaDto.FechaInicio.Replace("/", "")}_{informeAsistenciaDto.FechaTermino.Replace("/", "")}.xlsx";
                            
                            attachments.Add(new EmailAttachment
                            {
                                Content = excelData,
                                FileName = fileName,
                                ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"
                            });
                            
                            hasReports = true;
                            logger.LogInformation($"Generado informe HE100 con {resultados100.Count} registros");
                        }
                    }
                }

                // Enviar correo electrónico si hay informes generados
                if (hasReports && !string.IsNullOrEmpty(informeAsistenciaDto.Email))
                {
                    var subject = $"Informes de Asistencia - Período {informeAsistenciaDto.FechaInicio} al {informeAsistenciaDto.FechaTermino}";
                    var body = $@"
                        <html>
                        <body>
                            <h2>Informes de Asistencia</h2>
                            <p>Estimado/a,</p>
                            <p>Se adjuntan los informes de asistencia solicitados para el período del <strong>{informeAsistenciaDto.FechaInicio}</strong> al <strong>{informeAsistenciaDto.FechaTermino}</strong>.</p>
                            <p><strong>Centro de Costo:</strong> {informeAsistenciaDto.CentroCosto}</p>
                            <p><strong>Archivos generados:</strong> {attachments.Count}</p>
                            <ul>
                                {string.Join("", attachments.Select(a => $"<li>{a.FileName}</li>"))}
                            </ul>
                            <p>Saludos cordiales,<br/>Sistema de Gestión Administrativa SOLOVERDE S.A.</p>
                        </body>
                        </html>";

                    await emailService.SendEmailWithAttachmentsAsync(informeAsistenciaDto.Email, subject, body, attachments);
                    
                    resultado.Estado = "OK";
                    resultado.Mensaje = $"Informes generados y enviados exitosamente a {informeAsistenciaDto.Email}";
                    resultado.Cantidad = attachments.Count;
                    
                    logger.LogInformation($"Informes enviados exitosamente a {informeAsistenciaDto.Email}");
                }
                else if (!hasReports)
                {
                    resultado.Estado = "WARNING";
                    resultado.Mensaje = "No se encontraron datos para generar informes en el período especificado";
                }
                else
                {
                    resultado.Estado = "ERROR";
                    resultado.Mensaje = "Email de destino no especificado";
                }
                
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
