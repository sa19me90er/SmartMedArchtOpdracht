using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartMedArchtOpdracht.Buisiness_Logica.Entities;
using SmartMedArchtOpdracht.Buisiness_Logica.Services;

namespace SmartMedArchtOpdracht.UI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicineControllers : ControllerBase
    {

        private ILogger _logger;
        private IMedicineServices _service;


        public MedicineControllers(ILogger<MedicineControllers> logger, IMedicineServices service)
        {
            _logger = logger;
            _service = service;

        }

        [HttpGet("/api/medicines")]
        public ActionResult<List<Medicine>> GetMedicines()
        {
            return _service.GetMedicines();
        }

        [HttpPost("/api/medicines")]
        public ActionResult<Medicine> AddMedicine(Medicine medicine)
        {
            _service.AddMedicine(medicine);
            return medicine;
        }


        [HttpDelete("/api/medicines/{id}")]
        public ActionResult<string> DeleteProduct(string id)
        {
            _service.DeleteMedicine(id);
            return id;
        }
    }
}