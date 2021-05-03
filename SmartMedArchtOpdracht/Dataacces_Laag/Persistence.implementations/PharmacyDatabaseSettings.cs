using SmartMedArchtOpdracht.Dataacces_Laag.Persisitence;

namespace SmartMedArchtOpdracht.Dataacces_Laag.Persistence.implementations
{
    public class PharmacyDatabaseSettings : IPharmacyDatabaseSettings 
    {
        public string MedicineCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
