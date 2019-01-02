using System;
using System.Linq;

namespace HealthLevel7.ORM
{
    /// <summary>
    /// Diagnosis
    /// </summary>
    public class DG1
    {
        public string SetId { get; set; }
        public string DiagnosisCodingMethod { get; set; }
        public string DiagnosisCode { get; set; }
        public string DiagnosisDescription { get; set; }
        public string DiagnosisDateTime { get; set; }
        public string DiagnosisType { get; set; }
        public string MajorDiagnosticCategory { get; set; }
        public string DiagnosticRelatedGroup { get; set; }
        public string DRGApprovalIndicator { get; set; }
        public string DRGGrouperReviewCode { get; set; }
        public string OutlierType { get; set; }
        public string OutlierDays { get; set; }
        public string OutlierCost { get; set; }
        public string GrouperVersionAndType { get; set; }
        public string DiagnosisPriority { get; set; }
        public string DiagnosingClinician { get; set; }
        public string DiagnosisClassification { get; set; }
        public string ConfidentialIndicator { get; set; }
        public string AttestationDateTime { get; set; }


        public DG1 GetSegment(string segmentText)
        {
            var segment = new DG1();
            const string messageSegmentType = "DG1";

            if (string.IsNullOrWhiteSpace(segmentText) || segmentText.Substring(0, messageSegmentType.Length) != messageSegmentType)
            {
                throw new Exception($"{messageSegmentType}: {segmentText} does not start with {messageSegmentType}");
            }

            segmentText = segmentText.Substring(messageSegmentType.Length, segmentText.Length - messageSegmentType.Length);

            var fieldSeparator = segmentText.Substring(0, 1);
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
