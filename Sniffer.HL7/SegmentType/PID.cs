using System;
using System.Linq;

namespace Sniffer.HL7.SegmentType
{
    /// <summary>
    /// Patient Identification Row
    /// </summary>
    public class PID
    {
        public string SetId { get; set; }
        public string PatientExternalId { get; set; }
        [RequiredField]
        public string PatientInternalId { get; set; }
        public string PatientAlternateId { get; set; }
        [RequiredField]
        public string PatientName { get; set; }
        public string MothersMaidenName { get; set; }
        public string Birthday { get; set; }
        public string Sex { get; set; }
        public string PatientAlias { get; set; }
        public string Race { get; set; }
        public string PatientAddress { get; set; }
        //TODO: Value is B
        public string CountryCode { get; set; }
        public string HomePhoneNumber { get; set; }
        public string BusinessPhoneNumber { get; set; }
        public string PrimaryLanguage { get; set; }
        public string MaritalStatus { get; set; }
        public string Religion { get; set; }
        public string AccountNumber { get; set; }
        public string Ssn { get; set; }
        public string DriversLicenseNumber { get; set; }
        public string MothersIdentifier { get; set; }
        public string EthnicGroup { get; set; }
        public string BirthPlace { get; set; }
        public string MultipleBirthIndicator { get; set; }
        public string BirthOrder { get; set; }
        public string Citizenship { get; set; }
        public string VeteransMilitaryStatus { get; set; }
        public string Nationality { get; set; }
        public string PatientDeathDateandTime { get; set; }
        public string PatientDeathIndicator { get; set; }

        public PID GetSegment(string segmentText)
        {
            var segment = new PID();
            const string messageSegmentType = "PID";

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
