namespace Sniffer.HL7.SegmentType
{
    public class AIG
    {
        public string SetId { get; set; }
        public string SegmentActionCode { get; set; }
        public string ResourceId { get; set; }
        public string ResourceType { get; set; }
        public string ResourceGroup { get; set; }
        public string ResourceQuantity { get; set; }
        public string ResourceQuantityUnits { get; set; }
        public string StartDateTime { get; set; }
        public string StartDateTimeOffset { get; set; }
        public string StartDateTimeOffsetUnits { get; set; }
        public string Duration { get; set; }
        public string DurationUnits { get; set; }
        public string AllowSubstitutionCode { get; set; }
        public string FillerStatusCode { get; set; }

    }
}
