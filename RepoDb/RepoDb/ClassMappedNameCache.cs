﻿using RepoDb.Extensions;
using System;
using System.Collections.Concurrent;

namespace RepoDb
{
    /// <summary>
    /// A class used to cache the mapped-name for the entity.
    /// </summary>
    public static class ClassMappedNameCache
    {
        private static readonly ConcurrentDictionary<string, string> m_cache = new ConcurrentDictionary<string, string>();

        /// <summary>
        /// Gets the cached mapped-name for the entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the target entity.</typeparam>
        /// <returns>The cached mapped name of the data entity.</returns>
        public static string Get<TEntity>()
            where TEntity : class
        {
            return Get(typeof(TEntity));
        }

        /// <summary>
        /// Gets the cached mapped-name for the entity.
        /// </summary>
        /// <param name="type">The type of the target entity.</param>
        /// <returns>The cached command type of the entity.</returns>
        internal static string Get(Type type)
        {
            var key = type.FullName;
            var result = (string)null;
            if (m_cache.TryGetValue(key, out result) == false)
            {
                result = DataEntityExtension.GetMappedName(type);
                m_cache.TryAdd(key, result);
            }
            return result;
        }
    }
}
