using System;
using System.Collections.Generic;
using MongoDB.Driver;
using SmartMedArchtOpdracht.Buisiness_Logica.Entities;
using SmartMedArchtOpdracht.Buisiness_Logica.Services;
using SmartMedArchtOpdracht.Dataacces_Laag.Persisitence;

namespace SmartMedArchtOpdracht.Buisiness_Logica.Servics.implementations
{
    public class MedicineServices : IMedicineServices
    {
        private readonly IMongoCollection<Medicine> _medicine;

        public MedicineServices(IPharmacyDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _medicine = database.GetCollection<Medicine>(settings.MedicineCollectionName);
        }

        public List<Medicine> GetMedicines()
        {
            return _medicine.Find(medicine => true).ToList();
        }

        public Medicine AddMedicine(Medicine medicine)
        {
            try
            {
                if (GreaterThanZero.ValidateGerateThanZero(medicine.quantity))
                {

                    DateTime dateNow = DateTime.Now;
                    medicine.creationDate = dateNow;

                    _medicine.InsertOne(medicine);
                    return medicine;
                }
                else
                {
                    throw new Exception("Quantity must be greater than 0");
                }
            }
            catch
            {
                throw;
            }
        }

        public string DeleteMedicine(string id)
        {
            _medicine.DeleteOne(medicine => medicine.Id == id);

            return id;
        }

    }
}
