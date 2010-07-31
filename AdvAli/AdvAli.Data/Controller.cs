using System;
using System.Configuration;

namespace AdvAli.Data
{
    public class Controller
    {
        public static object CreateProvider()
        {
            AppSettingsReader reader = new AppSettingsReader();
            string types = string.Format("AdvAli.Data.{0}, AdvAli.Data.{0}", reader.GetValue("DbType", typeof(string)).ToString());
            Type t = Type.GetType(types);
            return Activator.CreateInstance(t);
        }
    }
}
