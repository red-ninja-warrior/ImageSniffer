using Sniffer.HL7.SegmentType;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sniffer.HL7
{
    public class Common
    {
        public static List<Descendent> GetElements<T>(string segmentText)
            where T: new()
        {
            T segment = new T();
            var dictionary = new List<Descendent>();

            var messageSegmentType = segment.GetType().Name;

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
                    dictionary.Add(new Descendent { Field = propertyInfo[i].Name, Value = fields[i] });
                }
            }

            return dictionary;
        }
    }
}
