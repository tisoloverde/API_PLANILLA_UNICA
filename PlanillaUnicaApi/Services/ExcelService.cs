using OfficeOpenXml;
using PlanillaUnicaApi.Models;

namespace PlanillaUnicaApi.Services
{
    public interface IExcelService
    {
        byte[] GenerateExcelReport(List<Rh_Informe_Salida_He> data, string reportType, string fechaInicio, string fechaTermino);
        byte[] GenerateExcelReport(List<Rh_Informe_Falta_Permiso> data, string reportType, string fechaInicio, string fechaTermino);
    }

    public class ExcelService : IExcelService
    {
        public byte[] GenerateExcelReport(List<Rh_Informe_Salida_He> data, string reportType, string fechaInicio, string fechaTermino)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            
            using var package = new ExcelPackage();
            var worksheet = package.Workbook.Worksheets.Add($"Informe {reportType}");

            // Encabezados
            var headers = new string[]
            {
                "Plantilla", "Contrato", "Concepto", "Valor", "Origen", 
                "Objeto", "Período de Pago", "Fecha Inicio", "Fecha Término", 
                "Institución", "Dato Adicional", "Comentario", "Valor Defecto", 
                "Centro Costo", "Acción"
            };

            // Agregar encabezados
            for (int i = 0; i < headers.Length; i++)
            {
                worksheet.Cells[1, i + 1].Value = headers[i];
                worksheet.Cells[1, i + 1].Style.Font.Bold = true;
                worksheet.Cells[1, i + 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                worksheet.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
            }

            // Agregar datos
            for (int row = 0; row < data.Count; row++)
            {
                var item = data[row];
                worksheet.Cells[row + 2, 1].Value = item.Plantilla;
                worksheet.Cells[row + 2, 2].Value = item.Contrato;
                worksheet.Cells[row + 2, 3].Value = item.Concepto;
                worksheet.Cells[row + 2, 4].Value = item.Valor;
                worksheet.Cells[row + 2, 5].Value = item.Origen;
                worksheet.Cells[row + 2, 6].Value = item.Objeto;
                worksheet.Cells[row + 2, 7].Value = item.PeriodoDePago;
                worksheet.Cells[row + 2, 8].Value = item.FechaInicio;
                worksheet.Cells[row + 2, 9].Value = item.FechaTermino;
                worksheet.Cells[row + 2, 10].Value = item.Institucion;
                worksheet.Cells[row + 2, 11].Value = item.DatoAdicional;
                worksheet.Cells[row + 2, 12].Value = item.Comentario;
                worksheet.Cells[row + 2, 13].Value = item.ValorDefecto;
                worksheet.Cells[row + 2, 14].Value = item.CentroCosto;
                worksheet.Cells[row + 2, 15].Value = item.Accion;
            }

            // Ajustar ancho de columnas automáticamente
            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

            // Agregar información del reporte en la parte superior
            worksheet.InsertRow(1, 3);
            worksheet.Cells[1, 1].Value = $"Informe de {reportType}";
            worksheet.Cells[1, 1].Style.Font.Size = 16;
            worksheet.Cells[1, 1].Style.Font.Bold = true;
            
            worksheet.Cells[2, 1].Value = $"Período: {fechaInicio} - {fechaTermino}";
            worksheet.Cells[2, 1].Style.Font.Bold = true;
            
            worksheet.Cells[3, 1].Value = $"Generado: {DateTime.Now:dd/MM/yyyy HH:mm}";

            return package.GetAsByteArray();
        }

        public string GenerateFileName(string reportType, string fechaInicio, string fechaTermino)
        {
            var fechaInicioFormatted = DateTime.TryParse(fechaInicio, out var startDate) 
                ? startDate.ToString("yyyyMMdd") 
                : fechaInicio.Replace("/", "").Replace("-", "");
                
            var fechaTerminoFormatted = DateTime.TryParse(fechaTermino, out var endDate) 
                ? endDate.ToString("yyyyMMdd") 
                : fechaTermino.Replace("/", "").Replace("-", "");

            return $"{reportType}_{fechaInicioFormatted}_{fechaTerminoFormatted}.xlsx";
        }

        public byte[] GenerateExcelReport(List<Rh_Informe_Falta_Permiso> data, string reportType, string fechaInicio, string fechaTermino)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            
            using var package = new ExcelPackage();
            var worksheet = package.Workbook.Worksheets.Add($"Informe {reportType}");

            // Encabezados
            var headers = new string[]
            {
                "Empleado ID", "Contratos", "Tipo", "Fecha Inicio", "Fecha Término", 
                "Días", "Descripción", "Tipo Medio Día", "Envía Email Supervisor", 
                "Número Licencia", "Días a Pagar", "No Rebaja", "Fecha Concepción", 
                "Fecha Aplicación", "Goce Sueldo", "Subtipo Ausencia", "Médico Tratante", 
                "Especialidad"
            };

            // Agregar encabezados
            for (int i = 0; i < headers.Length; i++)
            {
                worksheet.Cells[1, i + 1].Value = headers[i];
                worksheet.Cells[1, i + 1].Style.Font.Bold = true;
                worksheet.Cells[1, i + 1].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                worksheet.Cells[1, i + 1].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
            }

            // Agregar datos
            for (int row = 0; row < data.Count; row++)
            {
                var item = data[row];
                worksheet.Cells[row + 2, 1].Value = item.empleado_id;
                worksheet.Cells[row + 2, 2].Value = item.contratos;
                worksheet.Cells[row + 2, 3].Value = item.tipo;
                worksheet.Cells[row + 2, 4].Value = item.fecha_inicio;
                worksheet.Cells[row + 2, 5].Value = item.fecha_termino;
                worksheet.Cells[row + 2, 6].Value = item.dias;
                worksheet.Cells[row + 2, 7].Value = item.descripcion;
                worksheet.Cells[row + 2, 8].Value = item.tipo_medio_dia;
                worksheet.Cells[row + 2, 9].Value = item.envia_email_supervidor;
                worksheet.Cells[row + 2, 10].Value = item.numero_licencia;
                worksheet.Cells[row + 2, 11].Value = item.dias_a_pagar;
                worksheet.Cells[row + 2, 12].Value = item.no_rebaja;
                worksheet.Cells[row + 2, 13].Value = item.fecha_concepcion;
                worksheet.Cells[row + 2, 14].Value = item.fecha_aplicacion;
                worksheet.Cells[row + 2, 15].Value = item.goce_sueldo;
                worksheet.Cells[row + 2, 16].Value = item.subtipo_ausencia;
                worksheet.Cells[row + 2, 17].Value = item.medico_tratante;
                worksheet.Cells[row + 2, 18].Value = item.especialidad;
            }

            // Ajustar ancho de columnas automáticamente
            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

            // Agregar información del reporte en la parte superior
            worksheet.InsertRow(1, 3);
            worksheet.Cells[1, 1].Value = $"Informe de {reportType}";
            worksheet.Cells[1, 1].Style.Font.Size = 16;
            worksheet.Cells[1, 1].Style.Font.Bold = true;
            
            worksheet.Cells[2, 1].Value = $"Período: {fechaInicio} - {fechaTermino}";
            worksheet.Cells[2, 1].Style.Font.Bold = true;
            
            worksheet.Cells[3, 1].Value = $"Generado: {DateTime.Now:dd/MM/yyyy HH:mm}";

            return package.GetAsByteArray();
        }
    }
}