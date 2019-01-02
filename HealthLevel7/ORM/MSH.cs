using System;
using System.Linq;

namespace HealthLevel7.ORM
{
    /// <summary>
    /// MessageHeader Information
    /// </summary>
    public class MSH
    {
        [RequiredField]
        public string FieldSeparator { get; set; }
        [RequiredField]
        public string EncodingCharacters { get; set; }
        public string SendingApplication { get; set; }
        public string SendingFacility { get; set; }
        public string ReceivingApplication { get; set; }
        public string ReceivingFacility { get; set; }
        public string MessageDateTime { get; set; }
        public string Security { get; set; }
        [RequiredField]
        public string MessageType { get; set; }
        [RequiredField]
        public string MessageControlId { get; set; }
        [RequiredField]
        public string ProcessingId { get; set; }
        [RequiredField]
        public string VersionId { get; set; }
        public string SequenceNumber { get; set; }
        public string ContinuationPointer { get; set; }
        public string AcceptAcknowledgementType { get; set; }
        public string ApplicationAcknowledgementType { get; set; }
        public string CountryCode { get; set; }
        public string CharacterSet { get; set; }
        public string PrincipalLanguageOfMessage { get; set; }

        public MSH GetSegment(string segmentText)
        {
            var segment = new MSH();
            const string messageSegmentType = "MSH";

            if(string.IsNullOrWhiteSpace(segmentText) || segmentText.Substring(0, messageSegmentType.Length) != messageSegmentType)
            {
                throw new Exception($"{messageSegmentType}: {segmentText} does not start with {messageSegmentType}");
            }

            segmentText = segmentText.Substring(messageSegmentType.Length, segmentText.Length - messageSegmentType.Length);

            var fieldSeparator = segmentText.Substring(0, 1);
            var fields = segmentText.Split(fieldSeparator);
            if (fields.Any())
            {
                fields[0] = fieldSeparator;
            }
            
            var propertyInfo = segment.GetType().GetProperties();
            for(var i=0; i< propertyInfo.Length; i++)
            {
                var attribute = (RequiredFieldAttribute)propertyInfo[i].GetCustomAttributes(typeof(RequiredFieldAttribute), false).FirstOrDefault();

                if (attribute != null && attribute.Required && string.IsNullOrWhiteSpace(fields[i]))
                {
                    throw new Exception($"{messageSegmentType}: {segmentText} does not have mandatory field {propertyInfo[i].Name} at position {i + 1}");
                }

                if(i < fields.Length)
                {
                    propertyInfo[i].SetValue(segment, fields[i]);
                }               
            }
                        
            return segment;
        }
    }
}
