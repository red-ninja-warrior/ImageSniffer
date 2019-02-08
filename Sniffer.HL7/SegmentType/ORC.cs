using System;
using System.Linq;

namespace Sniffer.HL7.SegmentType
{
    /// <summary>
    /// Common Order
    /// </summary>
    public class ORC
    {
        [RequiredField]
        public string OrderControl { get; set; }
        public string PlacerOrderNumber { get; set; }
        public string FillerOrderNumber { get; set; }
        public string PlacerGroupNumber { get; set; }
        public string OrderStatus { get; set; }
        public string ResponseFlag { get; set; }
        public string QuantityOrTiming { get; set; }
        public string ParentOrder { get; set; }
        public string TransactionDateTime { get; set; }
        public string EnteredBy { get; set; }
        public string VerifiedBy { get; set; }
        public string OrderingProvider { get; set; }
        public string EnterersLocation { get; set; }
        public string CallBackPhoneNumber { get; set; }
        public string OrderEffectiveDateTime { get; set; }               
        public string OrderControlCodeReason { get; set; }
        public string EnteringOrganization { get; set; }
        public string EnteringDevice { get; set; }
        public string ActionBy { get; set; }
        public string AdvancedBeneficiaryNoticeCode { get; set; }
        public string OrderingFacilityName { get; set; }
        public string OrderingFacilityAddress { get; set; }
        public string OrderingFacilityPhoneNumber { get; set; }
        public string OrderingProviderAddress { get; set; }
        public string OrderStatusModifier { get; set; }
        public string AdvancedBeneficiaryNoticeOverrideReason { get; set; }
        public string FillersExpectedAvailabilityDateTime { get; set; }
        public string ConfidentialityCode { get; set; }
        public string OrderType { get; set; }
        public string EntererAuthorizationMode { get; set; }
        public string ParentUniversalServiceIdentifier { get; set; }


        public ORC GetSegment(string segmentText)
        {
            var segment = new ORC();
            const string messageSegmentType = "ORC";

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
