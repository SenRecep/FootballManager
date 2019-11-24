using FootballManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace FootballManager.Bll.Concrete.Validation
{
    public static class ValidationIsNullOrWhitespace
    {
     
        private static List<PropertyInfo> properties;
        private static List<object> propertiesValue;
        private static StringBuilder stringBuilder;

        public static string ValidationIsNullOrEmpty(object obj)
        {
            var type = obj.GetType();
            properties = new List<PropertyInfo>();
            propertiesValue = new List<object>();
            stringBuilder = new StringBuilder();
            GetProperties(type, obj);
            RemoveEntityBaseProperties();
            FindNullAndWhiteSpace(properties, stringBuilder);
           


            return stringBuilder.ToString();
        }

        public static StringBuilder FindNullAndWhiteSpace(List<PropertyInfo> properties, StringBuilder stringBuilder)
        {
            for (int i = 0; i < properties.Count; i++)
                if (propertiesValue[i] != null)
                {
                    if (string.IsNullOrWhiteSpace(propertiesValue[i].ToString()))
                        stringBuilder.AppendLine($"{properties[i].Name} Du kan ikke bruge mellemrum");
                }
                else
                    stringBuilder.AppendLine($"{properties[i].Name} Kan ikke være tom");// null


            return stringBuilder;
        }


        private static void GetProperties(Type type, object obj)
        {
            var props = type.GetProperties().Where(x => x.PropertyType.BaseType != typeof(EntityBase) && (!x.PropertyType.IsGenericType || x.PropertyType.GetGenericTypeDefinition().Equals(typeof(Nullable<>))));
            properties.AddRange(props);
            AddPropertiesValue(obj, props);
            var Xprops = type.GetProperties().Where(x => x.PropertyType.BaseType == typeof(EntityBase)).ToList();
            Xprops.ForEach(item =>
            {
                var _type = item.PropertyType;
                var _obj = item.GetValue(obj);
                if (_obj != null)
                    GetProperties(_type, _obj);
                else
                    stringBuilder.AppendLine($"{_type.Name} can not be null");
            });
        }
        private static void RemoveEntityBaseProperties()
        {
            var type = typeof(EntityBase);
            var props = type.GetProperties().ToList();
            props.ForEach(item =>
            {
                var list = properties.Where(x => x.Name == item.Name).ToList();
                list.ForEach(x => {
                    int index = properties.IndexOf(x);
                    propertiesValue.RemoveAt(index);
                    properties.RemoveAt(index);
                });
            });
        }
        private static void AddPropertiesValue(object obj, IEnumerable<PropertyInfo> props)
        {
            foreach (PropertyInfo item in props)
            {
                var x = item.GetValue(obj);
                propertiesValue.Add(x);
            }
        }
    }
}
