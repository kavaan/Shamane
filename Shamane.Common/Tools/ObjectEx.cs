using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Shamane.Common.Tools
{
    public class ObjectEx
    {
        public static List<TResult> ShallowCopy<TResult>(IEnumerable<object> sourceList)
        {
            var res = new List<TResult>();
            foreach (var entity in sourceList)
            {
                res.Add(ShallowCopy<TResult>(entity));
            }
            return res;
        }

        public static TResult ShallowCopy<TResult>(object source)
        {
            if (source == null)
                return default(TResult);

            // Get properties from EF that are read/write and not marked witht he NotMappedAttribute
            var sourceProperties = source.GetType()
                                    .GetProperties()
                                    .Where(p => p.CanRead && p.CanWrite);
            //&&  p.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute), true).Length == 0);
            //var newObj = new TResult();
            var targetProperties = typeof(TResult).GetProperties()
                .Where(p => p.CanRead && p.CanWrite);

            var newObj = Activator.CreateInstance<TResult>();

            foreach (var property in sourceProperties)
            {
                // Copy value
                try
                {

                    var prop = targetProperties.FirstOrDefault(p => p.Name == property.Name);

                    if (prop != null && prop.PropertyType.IsEquivalentTo(property.PropertyType))
                        prop.SetValue(newObj, property.GetValue(source, null), null);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }

            return newObj;
        }


        public static void Patch(object target, object source)
        {

            // Get properties from EF that are read/write and not marked witht he NotMappedAttribute
            var sourceProperties = source.GetType()
                .GetProperties()
                .Where(p => p.CanRead && p.CanWrite);
            //&&  p.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute), true).Length == 0);
            //var newObj = new TResult();
            var targetProperties = target.GetType().GetProperties()
                .Where(p => p.CanRead && p.CanWrite);



            foreach (var property in sourceProperties)
            {
                // Copy value
                try
                {

                    var prop = targetProperties.FirstOrDefault(p => p.Name == property.Name);

                    if (prop != null && prop.PropertyType.IsEquivalentTo(property.PropertyType))
                        prop.SetValue(target, property.GetValue(source, null), null);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }

        }

    }
}
