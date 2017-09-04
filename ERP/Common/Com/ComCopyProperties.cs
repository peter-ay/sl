using System;
using System.Reflection;

namespace ERP.Common
{
    public class ComCopyProperties
    {
        public static void Copy(object destination, object source, bool toUpCass = false)
        {
            if (destination == null || source == null) return;

            Type desType = source.GetType();
            foreach (PropertyInfo pi in desType.GetProperties())
            {
                try
                {
                    PropertyInfo des_PI = destination.GetType().GetProperty(pi.Name);
                    if (des_PI != null && des_PI.Name == pi.Name && des_PI.CanWrite && pi.CanRead)
                    {
                        if (des_PI.PropertyType == typeof(string))
                        {
                            des_PI.SetValue(destination, "", null);
                        }
                        else if (des_PI.PropertyType == typeof(bool))
                        {
                            des_PI.SetValue(destination, false, null);
                        }

                        else if (des_PI.PropertyType == typeof(Int32))
                        {
                            des_PI.SetValue(destination, 0, null);
                        }

                        else if (des_PI.PropertyType == typeof(decimal))
                        {
                            des_PI.SetValue(destination, Convert.ToDecimal(0), null);
                        }

                        else if (des_PI.PropertyType == typeof(double))
                        {
                            des_PI.SetValue(destination, Convert.ToDouble(0), null);
                        }

                        if (des_PI.PropertyType == typeof(string) && toUpCass)
                        {
                            des_PI.SetValue(destination, pi.GetValue(source, null).ToString().MyStr(), null);
                        }
                        else if (des_PI.PropertyType == typeof(string))
                        {
                            des_PI.SetValue(destination, pi.GetValue(source, null).ToString().Trim(), null);
                        }
                        else
                        {
                            des_PI.SetValue(destination, pi.GetValue(source, null), null);
                        }

                    }
                }
                catch
                { }
            }
        }
    }
}
