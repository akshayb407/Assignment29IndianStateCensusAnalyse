using NUnit.Framework;
using CensusAnalyzer;
using CensusAnalyzer.POCO;
using Newtonsoft.Json;
using System.Collections.Generic;
using CensusAnalyzer.DTO;
using static CensusAnalyzer.CensusAnalyzer;

namespace CensusAnalyzerTest
{
    public class CensusAnalyserTestTests
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        static string indianStateCensusFilePath = @"H:\All Asignment\Assignment29IndianStateCensus\CensusAnalyzer\CensusAnalyzerTest\IndiaStateCensusData.csv";
        static string wrongHeaderIndianCensusFilePath = @"H:\All Asignment\Assignment29IndianStateCensus\CensusAnalyzer\CensusAnalyzerTest\WrongHeaderIndiaStateCodes.csv";
        static string delimiterIndianCensusFilePath = @"H:\All Asignment\Assignment29IndianStateCensus\CensusAnalyzer\CensusAnalyzerTest\IndianStateCensusDelimeter.csv";
        static string wrongIndianStateCensusFilePath = @"H:\All Asignment\Assignment29IndianStateCensus\CensusAnalyzer\CensusAnalyzerTest\IndianData.csv";
        static string wrongIndianStateCensusFileType = @"H:\All Asignment\Assignment29IndianStateCensus\CensusAnalyzer\CensusAnalyzerTest\IndiaStateCensusData.txt";
        static string indianStateCodeFilePath = @"H:\All Asignment\Assignment29IndianStateCensus\CensusAnalyzer\CensusAnalyzerTest\IndiaStateCodes.CSV";
        static string wrongIndianStateCodeFileType = @"H:\All Asignment\Assignment29IndianStateCensus\CensusAnalyzer\CensusAnalyzerTest\IndiaStateCodes.txtCodes.txt";
        static string delimiterIndianStateCodeFilePath = @"H:\All Asignment\Assignment29IndianStateCensus\CensusAnalyzer\CensusAnalyzerTest\DelimiterIndiaStateCodes.csv";
        static string wrongHeaderStateCodeFilePath = @"H:\All Asignment\Assignment29IndianStateCensus\CensusAnalyzer\CensusAnalyzerTest\WrongHeaderIndiaStateCodes.csv";

        CensusAnalyzer.CensusAnalyzer censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyzer.CensusAnalyzer();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }
        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCodeFilePath, indianStateCodeHeaders);
            Assert.AreEqual(37, stateRecord.Count);
        }
        [Test]
        public void GivenIndianCensusDataFile_IfIncorret_ShouldThrowCustomException()
        {
            try
            {
                stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, delimiterIndianStateCodeFilePath, indianStateCodeHeaders);
            }
            catch (CensusAnalyzerException e)
            {
                Assert.AreEqual("File Not Found", e.Message);
            }
        }
        [Test]
        public void GivenIndianCensusDataFile_TypeIncorret_ShouldThrowCustomException()
        {
            try
            {
                stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCodeFileType, indianStateCodeHeaders);
            }
            catch (CensusAnalyzerException e)
            {
                Assert.AreEqual("Invalid File Type", e.Message);
            }
        }
        [Test]
        public void GivenIndianCensusDataFile_IncorrectDelimiter_ShouldThrowCustomException()
        {
            try
            {
                stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, delimiterIndianStateCodeFilePath, indianStateCodeHeaders);
            }
            catch (CensusAnalyzerException e)
            {
                Assert.AreEqual("File Contains Wrong Delimiter", e.Message);
            }
        }
        [Test]
        public void GivenIndianCensusDataFile_WrongHeader_ShouldThrowCustomException()
        {
            try
            {
                stateRecord = censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderStateCodeFilePath, indianStateCodeHeaders);
            }
            catch (CensusAnalyzerException e)
            {
                Assert.AreEqual("Incorrect header in Data", e.Message);
            }
        }
    }
}