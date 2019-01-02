using HealthLevel7.ORM;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HealthLevel7.Tests
{
    [TestClass]
    public class OrmTest
    {
        [TestMethod]
        public void MessageHeader()
        {
            var segmentText = @"MSH|^~\&|EPIC|EPIC|||20140418173314|1148|ORM^O01|497|D|2.3||";
            var segment = new MSH();
            var result = segment.GetSegment(segmentText);

            Assert.IsNotNull(result.MessageDateTime == "20140418173314");
        }

        [TestMethod]
        public void PatientIdentification()
        {
            var segmentText = @"PID|1||20891312^^^^EPI||APPLESEED^JOHN^A^^MR.^||19661201|M||AfrAm|505 S. HAMILTON AVE^^MADISON^WI^53505^US^^^DN |DN|(608)123-4567|(608)123-5678||S|| 11480003|123-45-7890||||^^^WI^^";
            var segment = new PID();
            var result = segment.GetSegment(segmentText);

            Assert.IsNotNull(result.PatientInternalId == "20891312^^^^EPI");
        }

        [TestMethod]
        public void PatientAdditionalDemographics()
        {
            var segmentText = @"PD1|||FACILITY(EAST)^^12345|1173^MATTHEWS^JAMES^A^^^";
            var segment = new PD1();
            var result = segment.GetSegment(segmentText);

            Assert.IsTrue(result.PatientPrimaryCareProviderNameId == "1173^MATTHEWS^JAMES^A^^^");
        }

        [TestMethod]
        public void PatientVisit()
        {
            var segmentText = @"PV1||E|^^^CARE HEALTH SYSTEMS^^^^^||| |1173^MATTHEWS^JAMES^A^^^||||||||||||610613||||||||||||||||||||||||||||||||V";
            var segment = new PV1();
            var result = segment.GetSegment(segmentText);

            Assert.IsTrue(result.PatientClass == "E");
        }

        [TestMethod]
        public void ObservationRequest()
        {
            var segmentText = @"OBR|1|2156286|A140875|MRSHLR-C^MR Shoulder right wo/contrast||| 20060220141000|||||";
            var segment = new OBR();
            var result = segment.GetSegment(segmentText);

            Assert.IsTrue(result.UniversalServiceID == "MRSHLR-C^MR Shoulder right wo/contrast");
        }


    }
}
