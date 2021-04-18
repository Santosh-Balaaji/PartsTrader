using NUnit.Framework;
using PartsTrader.ClientTools.Data;
using PartsTrader.ClientTools.Integration;
using PartsTrader.ClientTools.Utils;
using System.Collections.Generic;

namespace PartsTrader.ClientTools.Tests
{
    /// <summary>
    /// Tests for <see cref="PartCatalogue" />.
    /// </summary>
    [TestFixture]
    public class PartCatalogueTests
    {
        private IPartsTraderPartsService partService;
        private List<PartSummary> mockPartList;
        private List<PartSummary> mockExclusionList;
        [SetUp]
        public void Setup()
        {
            /* mockExclusionList.Add(new PartSummary() { PartNumber = "1111-TestData1", Description = "Test Data1" });
             mockExclusionList.Add(new PartSummary() { PartNumber = "1234-TestData2", Description = "Test Data2" });
             mockExclusionList.Add(new PartSummary() { PartNumber = "5555-TestData3", Description = "Test Data3" });*/
            mockExclusionList = new List<PartSummary>();
            mockPartList = new List<PartSummary>();

        }

        [Test]
        public void FetchCompatiableParts_PassingEmptyPartListandExclusionList_ReturnsEmptyList()
        {
            partService = new PartsTraderPartsService(mockPartList, mockExclusionList);
            var compatiableParts = partService.FindAllCompatibleParts("1111-ABCD");
            Assert.AreEqual(compatiableParts, new List<PartSummary>());
        }
        [Test]
        public void FetchCompatiableParts_PassingValidPartList_ConditionNotInExclusionList_ReturnsValidNumberandDesc()
        {
            mockPartList.Add(new PartSummary() { PartNumber = "1111-TestData1", Description = "Test Data1" });
            partService = new PartsTraderPartsService(mockPartList, mockExclusionList);
            var compatiableParts = partService.FindAllCompatibleParts("1111-TestData1");
            Assert.AreEqual(compatiableParts, mockPartList.Find(f=>f.PartNumber == "1111-TestData1"));
        }

        [Test]
        public void FetchCompatiableParts_PassingValidPartList_ConditionNotInExclusionListandPartList_ReturnsNull()
        {
            mockPartList.Remove(mockPartList.Find(f=>f.PartNumber == "1111-TestData1"));
            partService = new PartsTraderPartsService(mockPartList, mockExclusionList);
            var compatiableParts = partService.FindAllCompatibleParts("1111-TestData1");
            Assert.AreEqual(compatiableParts, null);
        }

        [Test]
        public void FetchCompatiableParts_PassingValidPartList_ConditionInExclusionListandPartList_ReturnsNull()
        {
            mockPartList.Add(new PartSummary() { PartNumber = "1111-TestData1", Description = "Test Data1" });
            mockExclusionList.Add(new PartSummary() { PartNumber = "1111-TestData1", Description = "Test Data1" });
            partService = new PartsTraderPartsService(mockPartList, mockExclusionList);
            var compatiableParts = partService.FindAllCompatibleParts("1111-TestData1");
            Assert.AreEqual(compatiableParts, null);
        }

        [Test]
        public void ValidatePartNumber_PassingInValidPartNumber_ReturnsFalse()
        {
            Assert.IsFalse(Validation.ValidatePartNumber("111A-ABCD"));
        }

        [Test]
        public void ValidatePartNumber_PassingInValidPartNumber_FormatPartNumberLengthLessThan4_ReturnsFalse()
        {
            Assert.IsFalse(Validation.ValidatePartNumber("111-ABCD"));
        }

        [Test]
        public void ValidatePartNumber_PassingInValidPartNumber_FormatPartIdContainingSpecialCharacter_ReturnsFalse()
        {
            Assert.IsFalse(Validation.ValidatePartNumber("111!-ABCD"));
        }

        [Test]
        public void ValidatePartNumber_PassingInValidPartNumber_FormatPartCodeContainingSpecialCharacter_ReturnsFalse()
        {
            Assert.IsFalse(Validation.ValidatePartNumber("1111-ABCD!"));
        }

        [Test]
        public void ValidatePartNumber_PassingInValidPartNumber_FormatPartCodeLengthLessThan4_ReturnsFalse()
        {
            Assert.IsFalse(Validation.ValidatePartNumber("1111-ABC"));
        }
        [Test]
        public void ValidatePartNumber_PassingValidPartNumber_FormatPartCodeContainingAplhaNumeric_ReturnsTrue()
        {
            Assert.IsTrue(Validation.ValidatePartNumber("1111-ABC11"));
        }

        [Test]
        public void ValidatePartNumber_PassingValidPartNumber_FormatPartidContaining4Numbers_ReturnsTrue()
        {
            Assert.IsTrue(Validation.ValidatePartNumber("1111-ABC11"));
        }

        [Test]
        public void ValidatePartNumber_PassingInValidPartNumber_FormatPartNumberContainingMorethan1dashes_ReturnsFalse()
        {
            Assert.IsFalse(Validation.ValidatePartNumber("1111-ABC11-123"));
        }

    }
}