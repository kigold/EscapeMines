using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TurtleChallenge.Extensions
{
    public static class EnumExtension
    {
        public static string GetDescription(this Enum value)
        {
            try
            {
                FieldInfo field = value.GetType().GetField(value.ToString());
                object[] attribs = field.GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (attribs.Length > 0)
                {
                    return ((DescriptionAttribute) attribs[0]).Description;
                }
                return value.ToString();
            }
            catch (Exception e)
            {
                return null;
            }           
        }
    }
}
