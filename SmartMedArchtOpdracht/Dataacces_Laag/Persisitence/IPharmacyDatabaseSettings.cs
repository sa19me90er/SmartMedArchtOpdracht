using System;
namespace SmartMedArchtOpdracht.Dataacces_Laag.Persisitence
{
    public interface IPharmacyDatabaseSettings
    {
        string MedicineCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
