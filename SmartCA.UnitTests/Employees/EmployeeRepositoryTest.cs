using SmartCA.Model.Employees;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using SmartCA.Infrastructure;
using SmartCA.Infrastructure.RepositoryFramework;

namespace SmartCA.UnitTests
{
    
    
    /// <summary>
    ///This is a test class for IEmployeeRepositoryTest and is intended
    ///to contain all IEmployeeRepositoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class IEmployeeRepositoryTest
    {
        private TestContext testContextInstance;
        private UnitOfWork unitOfWork;
        private IEmployeeRepository repository;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        
        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {
            this.unitOfWork = new UnitOfWork();
            this.repository = RepositoryFactory.GetRepository<IEmployeeRepository,
                Employee>(this.unitOfWork);
        }

        #endregion


        /// <summary>
        ///A test for GetPrincipals
        ///</summary>
        [DeploymentItem("SmartCA.sdf"), TestMethod()]
        public void GetPrincipalsTest()
        {
            // Get the list of all Principals
            IList<Employee> principals = this.repository.GetPrincipals();

            // Make sure there is at least one item in the list
            Assert.AreEqual(true, principals.Count > 0);
        }

        /// <summary>
        ///A test for GetConstructionAdministrators
        ///</summary>
        [DeploymentItem("SmartCA.sdf"), TestMethod()]
        public void GetConstructionAdministratorsTest()
        {
            // Get the list of all Construction Administrators
            IList<Employee> administrators = 
                this.repository.GetConstructionAdministrators();

            // Make sure there is at least one item in the list
            Assert.AreEqual(true, administrators.Count > 0);
        }
    }
}
