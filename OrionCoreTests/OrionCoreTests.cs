﻿using System;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrionCore.ErrorManagement;
using OrionCore;

namespace OrionCoreTests
{
    [TestClass]
    public class OrionCoreTests
    {
        #region Fields
        private static Exception xInnerException = new ArgumentException("Test exception;");
        private static String strLogFileDirectory = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "TestsLogs");
        //private static String strLogFilePath = Path.Combine("c:\\", "Temp", "XErrorManagerTests", "Error.log");
        //private static XHistoryFile xXHistoryFile;
        #endregion

        #region Initializations
        [TestInitialize]
        public void Initialize()
        {
            //    String strLogFileDirectoryPath;

            if (String.IsNullOrWhiteSpace(OrionCoreTests.strLogFileDirectory) == false)
            {
                if (Directory.Exists(OrionCoreTests.strLogFileDirectory) == false) Directory.CreateDirectory(OrionCoreTests.strLogFileDirectory);
                //        if (File.Exists(XCoreTests.strLogFilePath) == true) File.Delete(XCoreTests.strLogFilePath);

                //        XCoreTests.xXHistoryFile = new XHistoryFile(strLogFilePath);
            }
        }// Initialize()
        #endregion

        #region Test methods
        #region OrionDeployementInfos
        [TestCategory("OrionDeploymentInfos")]
        [TestMethod]
        public void OrionDeployementInfos_DataFolder_IsBaseDirectory()
        {
            Assert.AreEqual(OrionDeploymentInfos.DataFolder, AppDomain.CurrentDomain.BaseDirectory);
        }// OrionDeploymentInfos_DataFolder_IsBaseDirectory()
        [TestCategory("OrionDeploymentInfos")]
        [TestMethod]
        public void OrionDeployementInfos_UpdateFolder_XDeployment_DataFolder_IsBaseDirectoryUpdates()
        {
            Assert.AreEqual(OrionDeploymentInfos.UpdateFolder, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Updates"));
        }// OrionDeploymentInfos_UpdateFolder_XDeployment_DataFolder_IsBaseDirectoryUpdates()
        [TestCategory("OrionDeploymentInfos")]
        [TestMethod]
        public void OrionDeployementInfos_Version_NotNull()
        {
            Assert.IsNotNull(OrionDeploymentInfos.ApplicationVersion);
        }// OrionDeploymentInfos_Version_NotNull()
        [TestCategory("OrionDeploymentInfos")]
        [TestMethod]
        public void OrionDeployementInfos_VersionPublication_Dash()
        {
            Assert.AreEqual(OrionDeploymentInfos.PublicationVersion, String.Empty);
        }// OrionDeploymentInfos_VersionPublication_Dash()
        #endregion

        #region XException
        [TestCategory("OrionException")]
        [TestMethod]
        public void CreateOrionException_EmptyException_IsCreated()
        {
            OrionException xOrionException;

            xOrionException = new OrionException();

            Assert.IsNotNull(xOrionException);
        }// CreateOrionException_EmptyException_IsCreated()
        [TestCategory("OrionException")]
        [TestMethod]
        public void CreateOrionException_CustomMessage_IsCreated()
        {
            OrionException xOrionException;

            xOrionException = new OrionException("Test message;");

            Assert.IsNotNull(xOrionException);
            Assert.AreEqual(xOrionException.Message, "Test message;");
        }// CreateOrionException_CustomMessage_IsCreated()
        [TestCategory("OrionException")]
        [TestMethod]
        public void CreateOrionException_CustomMessageData_IsCreated()
        {
            OrionException xOrionException;

            xOrionException = new OrionException("Test message;", "DataTest1=DataValue1", "DataTest2=DataValue2", "DataTest3=DataValue3");

            Assert.IsNotNull(xOrionException);
            Assert.AreEqual(xOrionException.Message, "Test message;");
            Assert.IsNotNull(xOrionException.Data);
            Assert.AreEqual(xOrionException.Data.Contains("DataTest1"), true);
            Assert.AreEqual(xOrionException.Data["DataTest1"], "DataValue1");
            Assert.AreEqual(xOrionException.Data.Contains("DataTest2"), true);
            Assert.AreEqual(xOrionException.Data["DataTest2"], "DataValue2");
            Assert.AreEqual(xOrionException.Data.Contains("DataTest3"), true);
            Assert.AreEqual(xOrionException.Data["DataTest3"], "DataValue3");
        }// CreateOrionException_CustomMessageData_IsCreated()
        [TestCategory("OrionException")]
        [TestMethod]
        public void CreateOrionException_CustomMessageInnerException_IsCreated()
        {
            OrionException xOrionException;

            xOrionException = new OrionException("Test message;", OrionCoreTests.xInnerException);

            Assert.IsNotNull(xOrionException);
            Assert.AreEqual(xOrionException.Message, "Test message;");
            Assert.IsNotNull(xOrionException.InnerException);
            Assert.IsInstanceOfType(xOrionException.InnerException, typeof(ArgumentException));
        }// CreateOrionException_CustomMessageInnerException_IsCreated()
        [TestCategory("OrionException")]
        [TestMethod]
        public void CreateOrionException_CustomMessageInnerExceptionData_IsCreated()
        {
            OrionException xOrionException;

            xOrionException = new OrionException("Test message;", OrionCoreTests.xInnerException, "DataTest1=DataValue1", "DataTest2=DataValue2", "DataTest3=DataValue3");

            Assert.IsNotNull(xOrionException);
            Assert.AreEqual(xOrionException.Message, "Test message;");
            Assert.IsNotNull(xOrionException.InnerException);
            Assert.IsInstanceOfType(xOrionException.InnerException, typeof(ArgumentException));
            Assert.IsNotNull(xOrionException.Data);
            Assert.AreEqual(xOrionException.Data.Contains("DataTest1"), true);
            Assert.AreEqual(xOrionException.Data["DataTest1"], "DataValue1");
            Assert.AreEqual(xOrionException.Data.Contains("DataTest2"), true);
            Assert.AreEqual(xOrionException.Data["DataTest2"], "DataValue2");
            Assert.AreEqual(xOrionException.Data.Contains("DataTest3"), true);
            Assert.AreEqual(xOrionException.Data["DataTest3"], "DataValue3");
        }// CreateOrionException_CustomMessageInnerExceptionData_IsCreated()
        #endregion

        //#region XErrorManager Creation
        //[TestCategory("XErrorManager")]
        //[TestMethod]
        //public void CreateXErrorManager_Empty_IsCreated()
        //{
        //    XErrorManager xXErrorManager;

        //    xXErrorManager = new XErrorManager();

        //    Assert.IsNotNull(xXErrorManager);
        //}// CreateXErrorManager_Empty_IsCreated()
        //[TestCategory("XErrorManager")]
        //[TestMethod]
        //public void CreateXErrorManager_XHistoryFile1_IsCreated()
        //{
        //    XErrorManager xXErrorManager;

        //    xXErrorManager = new XErrorManager(XCoreTests.xXHistoryFile);

        //    Assert.IsNotNull(xXErrorManager);
        //    Assert.IsInstanceOfType(xXErrorManager.LogManager1, typeof(XHistoryFile));
        //}// CreateXErrorManager_XHistoryFile1_IsCreated()
        //[TestCategory("XErrorManager")]
        //[TestMethod]
        //public void CreateXErrorManager_XHistoryFile2_IsCreated()
        //{
        //    XErrorManager xXErrorManager;

        //    xXErrorManager = new XErrorManager(null, XCoreTests.xXHistoryFile);

        //    Assert.IsNotNull(xXErrorManager);
        //    Assert.IsInstanceOfType(xXErrorManager.LogManager1, typeof(XHistoryFile));
        //}// CreateXErrorManager_XHistoryFile2_IsCreated()
        //#endregion

        //#region Error reporting
        //[TestCategory("XErrorManager")]
        //[TestMethod]
        //public void ErrorReporting_Message_Reported()
        //{
        //    XErrorManager xXErrorManager;

        //    xXErrorManager = new XErrorManager(XCoreTests.xXHistoryFile);
        //    xXErrorManager.ReportError("Test Message;");

        //    Assert.AreEqual(xXErrorManager.ErrorReported, true);
        //    Assert.AreEqual(xXErrorManager.ErrorMessage, "Test Message;");
        //}// ErrorReporting_Message_Reported()
        //[TestCategory("XErrorManager")]
        //[TestMethod]
        //public void ErrorReporting_MessageException_Reported()
        //{
        //    XErrorManager xXErrorManager;

        //    xXErrorManager = new XErrorManager(XCoreTests.xXHistoryFile);
        //    xXErrorManager.ReportError("Test Message;", new XException("Test exception;"));

        //    Assert.AreEqual(xXErrorManager.ErrorReported, true);
        //    Assert.AreEqual(xXErrorManager.ErrorMessage, "Test Message;");
        //    Assert.IsInstanceOfType(xXErrorManager.ErrorException, typeof(XException));
        //    Assert.AreEqual(xXErrorManager.ErrorException.Message, "Test exception;");
        //}// ErrorReporting_MessageException_Reported()
        //[TestCategory("XErrorManager")]
        //[TestMethod]
        //public void ErrorReporting_MessageDisplayMessageException_Reported()
        //{
        //    XErrorManager xXErrorManager;

        //    xXErrorManager = new XErrorManager(XCoreTests.xXHistoryFile);
        //    xXErrorManager.ReportError("Test Message;", "Test display message;", new XException("Test exception;"));

        //    Assert.AreEqual(xXErrorManager.ErrorReported, true);
        //    Assert.AreEqual(xXErrorManager.ErrorMessage, "Test Message;");
        //    Assert.AreEqual(xXErrorManager.DisplayErrorMessage, "Test display message;");
        //    Assert.IsInstanceOfType(xXErrorManager.ErrorException, typeof(XException));
        //    Assert.AreEqual(xXErrorManager.ErrorException.Message, "Test exception;");
        //}// ErrorReporting_MessageDisplayMessageException_Reported()
        //[TestCategory("XErrorManager")]
        //[TestMethod]
        //public void ErrorReporting_Reset_Reseted()
        //{
        //    XErrorManager xXErrorManager;

        //    xXErrorManager = new XErrorManager(XCoreTests.xXHistoryFile);
        //    xXErrorManager.ReportError("Test Message;");
        //    xXErrorManager.Reset();

        //    Assert.IsFalse(xXErrorManager.ErrorReported);
        //    Assert.IsNull(xXErrorManager.DisplayErrorMessage);
        //}//ErrorReporting_Reset_Reseted()
        //#endregion

        //#region Miscellaneous
        //[TestCategory("XErrorManager")]
        //[TestMethod]
        //public void ParseStackTrace_Parse_Parsed()
        //{
        //    Boolean bWellFormattedLines;
        //    System.Collections.ObjectModel.Collection<String> strResultats;

        //    bWellFormattedLines = true;

        //    strResultats = XErrorManager.ParseStackTrace();
        //    foreach (String strResultatTemp in strResultats)
        //        if (strResultatTemp.Split(new String[] { " -> " }, StringSplitOptions.None).Length != 2)
        //        {
        //            bWellFormattedLines = false;
        //            break;
        //        }

        //    Assert.IsTrue(bWellFormattedLines);
        //}// ParseStackTrace_Parse_Parsed()
        //#endregion
        #endregion
    }
}
