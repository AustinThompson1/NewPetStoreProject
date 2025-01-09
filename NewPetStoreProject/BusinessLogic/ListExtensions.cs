using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPetStoreProject
{/// <summary>
/// Gets a generic list of in stock products.
/// </summary>
    public static class ListExtensions
    {
        public static List<T> InStock<T>(this List<T> list) where T : Product

        {
            return list
                .Where(x => x.Quantity > 0)
                .ToList();
        }
        public static T GetProductByName<T>(string name) where T : Product
        {
            try
            {
                if (typeof(T) == typeof(DogLeash))
                {
                    return _dogLeash[name] as T;
                }
                else if (typeof(T) == typeof(CatFood))
                {
                    return _catFood[name] as T;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            { return null; }
        }
    }
}
