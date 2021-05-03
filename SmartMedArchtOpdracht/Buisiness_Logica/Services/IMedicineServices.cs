using System.Collections.Generic;
using SmartMedArchtOpdracht.Buisiness_Logica.Entities;

namespace SmartMedArchtOpdracht.Buisiness_Logica.Services
{
    public interface IMedicineServices
    {
        public List<Medicine> GetMedicines();
        public Medicine AddMedicine(Medicine med);
        public string DeleteMedicine(string id);
    }
}
