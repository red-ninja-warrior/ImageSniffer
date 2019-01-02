using System;

namespace HealthLevel7
{
    public class RequiredFieldAttribute: Attribute
    {
        public bool Required { get; private set; }
        public RequiredFieldAttribute()
        {
            Required = true;
        }
    }
}
