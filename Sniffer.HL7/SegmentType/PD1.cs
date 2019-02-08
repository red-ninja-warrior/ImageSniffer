using System;
using System.Linq;

namespace Sniffer.HL7.SegmentType
{
    /// <summary>
    /// Patient Additional Demographics
    /// </summary>
    public class PD1
    {
        public string LivingDependency { get; set; }
        public string LivingArrangement { get; set; }
        public string PatientPrimaryFacility { get; set; }
        public string PatientPrimaryCareProviderNameId { get; set; }
        public string StudentIndicator { get; set; }
        public string Handicap { get; set; }
        public string LivingWillCode { get; set; }
        public string OrganDonorCode { get; set; }
        public string SeparateBill { get; set; }
        public string DuplicatePatient { get; set; }
        public string PublicityCode { get; set; }
        public string ProtectionIndicator { get; set; }
        public string ProtectionIndicatorEffectiveDate { get; set; }
        public string PlaceofWorship { get; set; }
        public string AdvanceDirectiveCode { get; set; }
        public string ImmunizationRegistryStatus { get; set; }              

        public string ImmunizationRegistryStatusEffectiveDate { get; set; }
        public string PublicityCodeEffectiveDate { get; set; }
        public string MilitaryBranch { get; set; }
        public string MilitaryRank { get; set; }
        public string MilitaryStatus { get; set; }

        public PD1 GetSegment(string segmentText)
        {
            var segment = new PD1();
            const string messageSegmentType = "PD1";

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
