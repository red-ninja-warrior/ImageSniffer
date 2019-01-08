namespace Sniffer.Dicom
{
    public class ImageTag
    {
        public string Tag { get; internal set; }
        public ushort Group { get; internal set; }
        public ushort Element { get; internal set; }
        public string Name { get; internal set; }
        public string Value { get; internal set; }
    }
}
