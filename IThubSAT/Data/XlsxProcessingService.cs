using OfficeOpenXml;

namespace IThubSAT.Data
{
    public class XlsxProcessingService
    {
        public XlsxProcessingService() 
        {
            ExcelPackage.License.SetNonCommercialPersonal("IThub");
        }
        
        public static IResult DownloadTemplate()
        {
            using var package = new ExcelPackage();

            var worksheet = package.Workbook.Worksheets.Add("Template");
            worksheet = GenerateHeaders(worksheet);

            var fileBytes = package.GetAsByteArray();
            return Results.File(
                fileBytes,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "WorkloadImportTemplate.xlsx"
            );
        }
    
        public static async Task<IResult> Export()
        {
            using var package = new ExcelPackage();

            var worksheet = package.Workbook.Worksheets.Add("Template");
            worksheet = await Task.Run(() => GenerateHeaders(worksheet));

            var fileBytes = package.GetAsByteArray();

            return Results.File(
                fileBytes,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "WorkloadImportTemplate.xlsx"
            );
        }

        private static ExcelWorksheet GenerateHeaders(ExcelWorksheet worksheet)
        {
            worksheet.Cells[1, 1].Value = "Кафедра";
            worksheet.Cells[1, 2].Value = "Курс";
            worksheet.Cells[1, 3].Value = "Группа";
            worksheet.Cells[1, 4].Value = "Подгруппа";
            worksheet.Cells[1, 5].Value = "Спортклуб";
            worksheet.Cells[1, 6].Value = "Дисциплина";
            worksheet.Cells[1, 7].Value = "Преподаватель";
            worksheet.Cells[1, 8].Value = "Часы в семестр";
            worksheet.Cells[1, 9].Value = "Часы в неделю";
            worksheet.Cells[1, 10].Value = "Уровень";
            worksheet.Cells[1, 11].Value = "Комментарий";
            worksheet.Cells[1, 12].Value = "Количество студентов в группе"; // возможно перенести на отдельный лист?
            worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

            return worksheet;
        }
    }
}
