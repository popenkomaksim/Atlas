#region License
// =================================================================================================
// Copyright 2018 DataArt, Inc.
// -------------------------------------------------------------------------------------------------
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this work except in compliance with the License.
// You may obtain a copy of the License in the LICENSE file, or at:
//
//  http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// =================================================================================================
#endregion
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataArt.Atlas.Infrastructure.Extensions
{
    public static class CollectionExtension
    {
        private static readonly Random Rng = new Random();

        public static T RandomElement<T>(this ICollection<T> collection)
        {
            return collection.ToList()[Rng.Next(collection.Count)];
        }

        public static IEnumerable<T> AppendItem<T>(this IEnumerable<T> sequence, T trailingItem)
        {
            if (sequence == null)
            {
                throw new ArgumentNullException(nameof(sequence));
            }

            foreach (var obj in sequence)
            {
                yield return obj;
            }

            yield return trailingItem;
        }
    }
}
