﻿using SmartCA.Infrastructure.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartCA.Model.Projects;
using System.Collections.Generic;
using SmartCA.Infrastructure.RepositoryFramework;
using SmartCA.Infrastructure;

namespace SmartCA.UnitTests
{
    /// <summary>
    ///This is a test class for ProjectRepositoryTest and is intended
    ///to contain all ProjectRepositoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ProjectRepositoryTest
    {
        private TestContext testContextInstance;
        private UnitOfWork unitOfWork;
        private IProjectRepository repository;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return this.testContextInstance;
            }
            set
            {
                this.testContextInstance = value;
            }
        }

        #region Additional test attributes
        
        /// <summary>
        /// Use TestInitialize to run code before running each test
        /// </summary>
        [TestInitialize()]
        public void MyTestInitialize()
        {
            this.unitOfWork = new UnitOfWork();
            this.repository = RepositoryFactory.GetRepository<IProjectRepository, 
                Project>(this.unitOfWork);
        }

        #endregion


        /// <summary>
        ///A test for FindBy(object sector, object segment, bool completed)
        ///</summary>
        [DeploymentItem("SmartCA.sdf"), TestMethod()]
        public void FindBySegmentsAndNotCompletedTest()
        {
            // Create a list of Market Segments
            List<MarketSegment> segments = new List<MarketSegment>();
            segments.Add(new MarketSegment(1, null, "test", "test"));

            // Pass the Market Segments into the FindBy method, and
            // specify Projects that have NOT completed yet
            IList<Project> projects = this.repository.FindBy(segments, false);

            // Make sure there is one project that matches the criteria
            Assert.AreEqual(1, projects.Count);
        }

        /// <summary>
        ///A test for FindBy(string projectNumber)
        ///</summary>
        [DeploymentItem("SmartCA.sdf"), TestMethod()]
        public void FindByProjectNumberTest()
        {
            // The Project Number
            string projectNumber = "12345.00";

            // Try to get the Project
            Project project = this.repository.FindBy(projectNumber);

            // Verify the Project is there and is the right one
            Assert.AreEqual("My Project", project.Name);
        }

        /// <summary>
        ///A test for FindBy(object key)
        ///</summary>
        [DeploymentItem("SmartCA.sdf"), TestMethod()]
        public void FindByKeyTest()
        {
            object key = "5704f6b9-6ffa-444c-9583-35cc340fce2a";
            Project project = this.repository.FindBy(key);
            Assert.AreEqual("My Project", project.Name);
        }

        /// <summary>
        ///A test for FindAll()
        ///</summary>
        [DeploymentItem("SmartCA.sdf"), TestMethod()]
        public void FindAllTest()
        {
            IList<Project> projects = this.repository.FindAll();
            Assert.AreEqual(true, projects.Count > 0);
        }

        /// <summary>
        ///A test for FindAllMarketSegments()
        ///</summary>
        [DeploymentItem("SmartCA.sdf"), TestMethod()]
        public void FindAllMarketSegmentsTest()
        {
            // Get the list of all Market Segments
            IList<MarketSegment> segments = 
                this.repository.FindAllMarketSegments();

            // Make sure there is at least one item in the list
            Assert.AreEqual(true, segments.Count > 0);
        }
    }
}
