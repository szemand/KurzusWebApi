using ManagerApp.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ManagerApp.Tests
{
    [TestClass]
    public class CustomerFormValidationTests
    {
        [DataRow("Test Name", true)]
        [DataRow("Test", true)]
        [DataRow("", false)]
        [DataRow("   ", false)]
        [DataRow("Test-Name", false)]
        [DataRow("..", false)]
        [DataTestMethod]
        public void Customer_WithValidArgument_Name(string name, bool expectedOutcome)
        {
            // Arrange
            var cust = new Customer { Name = name };

            // Act
            var isValid = !ValidateModel(cust).Any(v => v.MemberNames.Contains("Name"));

            // Assert
            Assert.AreEqual(isValid, expectedOutcome);
        }

        [DataRow("Test Car", true)]
        [DataRow("Car", true)]
        [DataRow("   ", false)]
        [DataRow("VW Golf 1.9 TDI", false)]
        [DataTestMethod]
        public void Customer_WithValidArgument_CarType(string carType, bool expectedOutcome)
        {
            // Arrange
            var cust = new Customer { CarType = carType };

            // Act
            var isValid = !ValidateModel(cust).Any(v => v.MemberNames.Contains("CarType"));

            // Assert
            Assert.AreEqual(isValid, expectedOutcome);
        }

        [DataRow("KSL-384", true)]
        [DataRow("KSL 384", false)]
        [DataRow("ksl-384", false)]
        [DataRow("KS2-384", false)]
        [DataRow("PISTI-1", false)]
        [DataTestMethod]
        public void Customer_WithValidArgument_LicensePlate(string licensePlate, bool expectedOutcome)
        {
            // Arrange
            var cust = new Customer { LicensePlate = licensePlate };

            // Act
            var isValid = !ValidateModel(cust).Any(v => v.MemberNames.Contains("LicensePlate"));

            // Assert
            Assert.AreEqual(isValid, expectedOutcome);
        }

        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }
    }
}