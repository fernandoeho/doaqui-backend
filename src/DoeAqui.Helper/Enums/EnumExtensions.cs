using System;
using System.Collections.Generic;

namespace DoeAqui.Helper.Enums
{
    public static class EnumExtensions
    {
        public static IEnumerable<EnumValue> GetValues<T>()
        {
            List<EnumValue> values = new List<EnumValue>();

            foreach (var itemType in Enum.GetValues(typeof(T)))
            {
                values.Add(new EnumValue()
                {
                    Name = Enum.GetName(typeof(T), itemType),
                    Value = (int)itemType
                });
            }

            return values;
        }
    }
}