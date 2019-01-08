using System;
using System.Linq;

namespace Sniffer.HL7.ORM
{
    /// <summary>
    /// Observation Request
    /// </summary>
    public class OBR
    {
        public string SetId { get; set; }
        public string PlacerOrderNumber { get; set; }
        public string FillerOrderNumber { get; set; }
        [RequiredField]
        public string UniversalServiceID { get; set; }
        public string Priority { get; set; }
        public string RequestedDateTime { get; set; }
        public string ObservationDateTime { get; set; }
        public string ObservationEndDateTime { get; set; }
        public string CollectionVolume { get; set; }
        public string CollectorIdentifier { get; set; }
        public string SpecimenActionCode { get; set; }
        public string DangerCode { get; set; }
        public string RelevantClinicalInfo { get; set; }
        public string SpecimenReceivedDateTime { get; set; }
        public string SpecimenSource { get; set; }
        public string OrderingProvider { get; set; }
        public string OrderCallbackPhoneNumber { get; set; }
        public string Placerfield1 { get; set; }
        public string Placerfield2 { get; set; }
        public string FillerField1 { get; set; }
        public string FillerField2 { get; set; }
        public string ResultsReportedOrStatusChangedDateTime { get; set; }
        public string ChargeToPractice { get; set; }
        public string DiagnosticServSectID { get; set; }
        public string ResultStatus { get; set; }
        public string ParentResult { get; set; }
        public string QuantityOrTiming { get; set; }
        public string ResultCopiesTo { get; set; }
        public string Parent { get; set; }
        public string TransportationMode { get; set; }
        public string ReasonforStudy { get; set; }
        public string PrincipalResultInterpreter { get; set; }
        public string AssistantResultInterpreter { get; set; }
        public string Technician { get; set; }
        public string Transcriptionist { get; set; }
        public string ScheduledDateTime { get; set; }
        public string NumberofSampleContainers { get; set; }
        public string TransportLogisticsofCollectedSample { get; set; }
        public string CollectorsComment { get; set; }
        public string TransportArrangementResponsibility { get; set; }
        public string TransportArranged { get; set; }
        public string EscortRequired { get; set; }
        public string PlannedPatientTransportComment { get; set; }


        public OBR GetSegment(string segmentText)
        {
            var segment = new OBR();
            const string messageSegmentType = "OBR";

            if (string.IsNullOrWhiteSpace(segmentText) || segmentText.Substring(0, messageSegmentType.Length) != messageSegmentType)
            {
                throw new Exception($"{messageSegmentType}: {segmentText} does not start with {messageSegmentType}");
            }

            segmentText = segmentText.Substring(messageSegmentType.Length, segmentText.Length - messageSegmentType.Length);

            var fieldSeparator = char.Parse(segmentText.Substring(0, 1));
            segmentText = segmentText.Substring(1, segmentText.Length - 1); //Remove the first field Separator
            var fields = segmentText.Split(fieldSeparator);

            var propertyInfo = segment.GetType().GetProperties();
            for (var i = 0; i < propertyInfo.Length; i++)
            {
                var attribute = (RequiredFieldAttribute)propertyInfo[i].GetCustomAttributes(typeof(RequiredFieldAttribute), false).FirstOrDefault();

                if (attribute != null && attribute.Required && string.IsNullOrWhiteSpace(fields[i]))
                {
                    throw new Exception($"{messageSegmentType}: {segmentText} does not have mandatory field {propertyInfo[i].Name} at position {i + 1}");
                }

                if (i < fields.Length)
                {
                    propertyInfo[i].SetValue(segment, fields[i]);
                }
            }

            return segment;
        }

    }
}
