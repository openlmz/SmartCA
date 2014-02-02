using SmartCA.Model.Projects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace SmartCA.UnitTests
{
    
    
    /// <summary>
    ///This is a test class for ProjectServiceTest and is intended
    ///to contain all ProjectServiceTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ProjectServiceTest
    {


        private TestContext testContextInstance;

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
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for GetAllProjects
        ///</summary>
        [DeploymentItem("SmartCA.sdf"), TestMethod()]
        public void GetAllProjectsTest()
        {
            // Get the list of all Projects
            IList<Project> projects = ProjectService.GetAllProjects();

            // Make sure that there is at least one
            Assert.AreEqual(true, projects.Count > 0);
        }

        /// <summary>
        ///A test for GetMarketSegments
        ///</summary>
        [DeploymentItem("SmartCA.sdf"), TestMethod()]
        public void GetMarketSegmentsTest()
        {
            // Get the list of all Market Segments
            IList<MarketSegment> segments = ProjectService.GetMarketSegments();

            // Make sure that there is at least one
            Assert.AreEqual(true, segments.Count > 0);
        }

        /// <summary>
        ///A test for SaveProject
        ///</summary>
        [DeploymentItem("SmartCA.sdf"), TestMethod()]
        public void SaveProjectTest()
        {
            // Get the first Project
            IList<Project> projects = ProjectService.GetAllProjects();
            Project project = projects[0];

            // Change its remarks
            project.Remarks = "This is a test remark.";

            // Try to save it
            ProjectService.SaveProject(project);

            // Get the first project again
            IList<Project> refreshedProjects = ProjectService.GetAllProjects();
            Project  refreshedProject = refreshedProjects[0];

            // Verify that the remarks were saved
            Assert.AreEqual("This is a test remark.", project.Remarks);
        }
    }
}
