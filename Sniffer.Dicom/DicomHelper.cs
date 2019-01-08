using Dicom;
using System.Collections.Generic;
using System.Linq;

namespace Sniffer.Dicom
{
    public class DicomHelper
    {
        public IEnumerable<ImageTag> GetDicomTags(string path)
        {
            var file = DicomFile.Open(path);
            var value = string.Empty;

            var tags = file.Dataset
                .Where(x => x.ValueRepresentation != null && x.ValueRepresentation.IsString)
                .Select(x => new ImageTag
                {
                    Tag = x.ToString(),
                    Name = x.Tag.DictionaryEntry.Name,
                    Value = file.Dataset.GetString(x.Tag),
                    Group = x.Tag.Group,
                    Element = x.Tag.Element
                })
                .OrderBy(i => i.Group)
                .ThenBy(i => i.Name)
                .ToList();

            return tags;
        }
    }
}
