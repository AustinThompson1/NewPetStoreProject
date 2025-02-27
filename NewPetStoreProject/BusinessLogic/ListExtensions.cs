﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetStore.Data;

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
       
    }
}
