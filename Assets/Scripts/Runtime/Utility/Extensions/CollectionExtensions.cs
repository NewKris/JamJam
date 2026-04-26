using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

namespace JamJam.Runtime.Utility.Extensions {
    public static class CollectionExtensions {
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> action) {
            foreach (T item in collection) {
                action(item);
            }
        }

        public static T GetRandom<T>(this T[] array) {
            int randIndex = Random.Range(0, array.Length);
            return array[randIndex];
        }
    }
}
