using System;
using SmartMedArchtOpdracht.Buisiness_Logica.Entities;
using SmartMedArchtOpdracht.Buisiness_Logica.Services;
using Xunit;
using Moq;
using SmartMedArchtOpdracht.Buisiness_Logica.Servics.implementations;

namespace SmartMedArchtOpdracht.Tests
{
    public class MedicineServiceUnitTest
    {
        [Fact]
        public void GreterThanZeroTest()
        {
            Medicine medicine1 = new Medicine { Id = "iddWRFV1", name = "parecitmol", quantity = 2, creationDate = DateTime.Now };
            Medicine medicine2 = new Medicine { Id = "iddWRFV2", name = "parecitmol", quantity = -20, creationDate = DateTime.Now };

            Assert.True(GreaterThanZero.ValidateGerateThanZero(medicine1.quantity));
            Assert.False(GreaterThanZero.ValidateGerateThanZero(medicine2.quantity));

        }
    }
}
