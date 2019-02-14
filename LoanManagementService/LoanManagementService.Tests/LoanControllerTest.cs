using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using LoanManagementService.Controllers;
using LoanDAL;
using LoanModel;
using System.Web.Http;
using System.Web.Http.Results;
using Moq;

namespace LoanManagementService.Tests
{
    /// <summary>
    /// Summary description for LoanControllerTest
    /// </summary>
    [TestClass]
    public class LoanControllerTest
    {
        /// <summary>
        /// TEST method for Mock Get vs Actual Get
        /// </summary>
        [TestMethod]
        public void GetLoans_For_ID_1_Moq_DAL()
        {
            // SetUp/ Arrange
            var mock = new Mock<ILoanDataAccess>();
            mock.Setup(p => p.GetLoanListDetails("1")).Returns(new List<Loan>() {
                new Loan() {
                           UserName = "Ramesh",
                           LoanName = "Loan Name",
                           LoanID = 1,
                           Balance = 12,
                           Interest = 21,
                           EarlyPaymentFee =23,
                           PayOutCarryOver = 333
                } });

            // Act
            LoanController loan = new LoanController(mock.Object);
            var result = loan.GetLoans("1");

            // Asert
            Assert.IsNotNull(result);
            // Assert.AreEqual(1, result.)
        }

        /// <summary>
        /// Validation for Invalid request  
        /// </summary>
        [TestMethod]
        public void GetReturnsNotFound()
        {
            // Arrange
            var mock = new Mock<ILoanDataAccess>();
            mock.Setup(p => p.GetLoanListDetails("1")).Returns(new List<Loan>() {
                new Loan() {
                           UserName = "Ramesh",
                           LoanName = "Loan Name",
                           LoanID = 1,
                           Balance = 12,
                           Interest = 21,
                           EarlyPaymentFee =23,
                           PayOutCarryOver = 333
                } });

            // Act
            var result = new LoanController(mock.Object);
            IHttpActionResult actionResult = result.GetLoans("10");

            // Assert
            Assert.IsInstanceOfType(actionResult, typeof(NotFoundResult));
        }

        /// <summary>
        /// Validation for getLoans BY ID 1
        /// </summary>
        [TestMethod]
        public void Compare_Result_Of_GetLoans_by_ID_1()
        {
            // SetUp/ Arrange
            var mock = new Mock<ILoanDataAccess>();
            mock.Setup(p => p.GetLoanListDetails("1")).Returns(new List<Loan>() {
                new Loan() {
                           UserName = "Ramesh",
                           LoanName = "Loan Name",
                           LoanID = 1,
                           Balance = 12,
                           Interest = 21,
                           EarlyPaymentFee =23,
                           PayOutCarryOver = 333
                } });

            // Act
            LoanController loan = new LoanController(mock.Object);
            var result = loan.GetLoans("1") as OkNegotiatedContentResult<List<Loan>>; ;

            // Asert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Content[0].LoanID);
        }
    }
}
