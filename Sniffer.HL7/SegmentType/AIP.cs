namespace Sniffer.HL7.SegmentType
{
    public class AIP
    {
        public string SetId { get; set; }
        public string SegmentActionCode { get; set; }
        public string PersonnelResourceId { get; set; }
        public string ResourceRole { get; set; }
        public string ResourceGroup { get; set; }
        public string StartDateTime { get; set; }
        public string StartDateTimeOffset { get; set; }
        public string StartDateTimeOffsetUnits { get; set; }
        public string Duration { get; set; }
        public string DurationUnits { get; set; }
        public string AllowSubstitutionCode { get; set; }
        public string FillerStatusCode { get; set; }

    }
}
