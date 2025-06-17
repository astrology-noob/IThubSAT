using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IThubSAT.Data
{
    public class WorkloadImport
    {
        // какие методы нужны
        // загрузка файла (проверка всё ли ок)
        // проверка на соблюдение шаблона
        // чтение строк
        // пустые строки должен пропускать, идёт до первой пустой строки
        // создание новых сущностей
        // проверка наличия сущности по названию (проверка наличия препода)
        // сохранение в бд

        // GET: Products/Import
        // Displays the file upload form and a link to download the Excel template.
        public IActionResult Import()
        {
            var model = new ProductImportViewModel();
            return View(model);
        }
        // GET: Products/DownloadTemplate
        // Allows the user to download the Excel template for product import.
        public IActionResult DownloadTemplate()
        {
            // Define the Excel file template on the fly using EPPlus.
            ExcelPackage.License.SetNonCommercialPersonal("IThub");
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Template");
                // Set headers (columns):
                // 1: Product Name, 2: Description, 3: Price, 4: Quantity,
                // 5: Category Name, 6: Supplier Name, 7: Supplier Email, 8: Supplier Phone,
                // 9: Brand, 10: Discount Percentage, 11: IsActive (true/false)
                worksheet.Cells[1, 1].Value = "Product Name";
                worksheet.Cells[1, 2].Value = "Description";
                worksheet.Cells[1, 3].Value = "Price";
                worksheet.Cells[1, 4].Value = "Quantity";
                worksheet.Cells[1, 5].Value = "Category Name";
                worksheet.Cells[1, 6].Value = "Supplier Name";
                worksheet.Cells[1, 7].Value = "Supplier Email";
                worksheet.Cells[1, 8].Value = "Supplier Phone";
                worksheet.Cells[1, 9].Value = "Brand";
                worksheet.Cells[1, 10].Value = "Discount Percentage";
                worksheet.Cells[1, 11].Value = "IsActive (true/false)";
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();
                var fileBytes = package.GetAsByteArray();
                return File(
                    fileBytes,
                    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                    "ProductImportTemplate.xlsx"
                );
            }
        }

        // POST: Products/Import
        // Processes the uploaded Excel file, validates each product, and displays an import summary.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Import(ProductImportViewModel model)
        {
            if (model.FileUpload == null || model.FileUpload.Length == 0)
            {
                ModelState.AddModelError("", "Please select an Excel file to upload.");
                return View(model);
            }
            // Set EPPlus license context for non-commercial use.
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            int successCount = 0;
            var importResults = new List<ProductImportResult>();
            using (var stream = new MemoryStream())
            {
                await model.FileUpload.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets.FirstOrDefault();
                    if (worksheet == null)
                    {
                        ModelState.AddModelError("", "No worksheet found in Excel file.");
                        return View(model);
                    }
                    int rowCount = worksheet.Dimension.Rows;
                    // Loop from row 2 (assuming row 1 contains headers)
                    for (int row = 2; row <= rowCount; row++)
                    {
                        // Expected columns:
                        // 1: Product Name, 2: Description, 3: Price, 4: Quantity,
                        // 5: Category Name, 6: Supplier Name, 7: Supplier Email, 8: Supplier Phone,
                        // 9: Brand, 10: Discount Percentage, 11: IsActive
                        string productName = worksheet.Cells[row, 1].Text.Trim();
                        string description = worksheet.Cells[row, 2].Text.Trim();
                        string priceText = worksheet.Cells[row, 3].Text.Trim();
                        string quantityText = worksheet.Cells[row, 4].Text.Trim();
                        string categoryName = worksheet.Cells[row, 5].Text.Trim();
                        string supplierName = worksheet.Cells[row, 6].Text.Trim();
                        string supplierEmail = worksheet.Cells[row, 7].Text.Trim();
                        string supplierPhone = worksheet.Cells[row, 8].Text.Trim();
                        string brand = worksheet.Cells[row, 9].Text.Trim();
                        string discountText = worksheet.Cells[row, 10].Text.Trim();
                        string isActiveText = worksheet.Cells[row, 11].Text.Trim();
                        // Skip rows with an empty product name.
                        if (string.IsNullOrEmpty(productName))
                            continue;
                        var importResult = new ProductImportResult { ProductName = productName };
                        try
                        {
                            decimal price = decimal.Parse(priceText);
                            int quantity = int.Parse(quantityText);
                            decimal discount = string.IsNullOrEmpty(discountText) ? 0 : decimal.Parse(discountText);
                            bool isActive = bool.Parse(isActiveText);
                            // Retrieve or create Category.
                            var category = await _context.Categories.FirstOrDefaultAsync(c => c.Name == categoryName);
                            if (category == null)
                            {
                                category = new Category { Name = categoryName, Description = "" };
                                _context.Categories.Add(category);
                                // Do not save here; let the transaction handle it.
                            }
                            // Retrieve or create Supplier.
                            var supplier = await _context.Suppliers.FirstOrDefaultAsync(s => s.Name == supplierName);
                            if (supplier == null)
                            {
                                supplier = new Supplier
                                {
                                    Name = supplierName,
                                    ContactEmail = supplierEmail,
                                    PhoneNumber = supplierPhone
                                };
                                _context.Suppliers.Add(supplier);
                            }
                            // Generate the SKU dynamically.
                            string generatedSKU = GenerateSKU(categoryName, brand, productName, supplier.Name);
                            // Check if a product with the generated SKU already exists.
                            var product = await _context.Products.FirstOrDefaultAsync(p => p.SKU == generatedSKU);
                            if (product == null)
                            {
                                // Create a new product.
                                product = new Product
                                {
                                    Name = productName,
                                    Description = description,
                                    Price = price,
                                    Quantity = quantity,
                                    Brand = brand,
                                    DiscountPercentage = discount,
                                    IsActive = isActive,
                                    Category = category,
                                    Supplier = supplier,
                                    SKU = generatedSKU
                                };
                                // Validate the new product.
                                var validationContext = new ValidationContext(product, null, null);
                                var validationResults = new List<ValidationResult>();
                                if (!Validator.TryValidateObject(product, validationContext, validationResults, true))
                                {
                                    importResult.Success = false;
                                    importResult.Message = string.Join("; ", validationResults.Select(v => v.ErrorMessage));
                                    importResults.Add(importResult);
                                    continue;
                                }
                                _context.Products.Add(product);
                            }
                            else
                            {
                                // Update existing product.
                                product.Description = description;
                                product.Price = price;
                                product.Quantity = quantity;
                                product.Brand = brand;
                                product.DiscountPercentage = discount;
                                product.IsActive = isActive;
                                product.Category = category;
                                product.Supplier = supplier;
                                var validationContext = new ValidationContext(product, null, null);
                                var validationResults = new List<ValidationResult>();
                                if (!Validator.TryValidateObject(product, validationContext, validationResults, true))
                                {
                                    importResult.Success = false;
                                    importResult.Message = string.Join("; ", validationResults.Select(v => v.ErrorMessage));
                                    importResults.Add(importResult);
                                    continue;
                                }
                                _context.Products.Update(product);
                            }
                            importResult.Success = true;
                            importResult.Message = "Processed successfully.";
                            importResults.Add(importResult);
                            successCount++;
                        }
                        catch (Exception ex)
                        {
                            importResult.Success = false;
                            importResult.Message = $"Exception: {ex.Message}";
                            importResults.Add(importResult);
                        }
                    } // end for loop
                }
            }
            // Use an explicit transaction to commit all changes as a batch.
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    ModelState.AddModelError("", "An error occurred while saving changes: " + ex.Message);
                    // Optionally, log the error.
                }
            }
            model.ImportResults = importResults;
            model.Message = $"Import process completed. {successCount} products processed successfully. See summary below.";
            return View(model);
        }
    }
}
