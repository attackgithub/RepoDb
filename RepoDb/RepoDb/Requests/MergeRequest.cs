﻿using RepoDb.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace RepoDb.Requests
{
    /// <summary>
    /// A class that holds the value of the merge operation arguments.
    /// </summary>
    internal class MergeRequest : BaseRequest, IEquatable<MergeRequest>
    {
        private int? m_hashCode = null;

        /// <summary>
        /// Creates a new instance of <see cref="MergeRequest"/> object.
        /// </summary>
        /// <param name="entityType">The entity type.</param>
        /// <param name="qualifiers">The list of qualifier fields.</param>
        /// <param name="connection">The connection object.</param>
        /// <param name="statementBuilder">The statement builder.</param>
        public MergeRequest(Type entityType, IDbConnection connection, IEnumerable<Field> qualifiers = null, IStatementBuilder statementBuilder = null)
            : base(entityType, connection, statementBuilder)
        {
            Qualifiers = qualifiers;
        }

        /// <summary>
        /// Gets the qualifier fields.
        /// </summary>
        public IEnumerable<Field> Qualifiers { get; set; }

        // Equality and comparers

        /// <summary>
        /// Returns the hashcode for this <see cref="MergeRequest"/>.
        /// </summary>
        /// <returns>The hashcode value.</returns>
        public override int GetHashCode()
        {
            // Make sure to return if it is already provided
            if (!ReferenceEquals(null, m_hashCode))
            {
                return m_hashCode.Value;
            }

            // Get first the entity hash code
            var hashCode = string.Concat(EntityType.FullName, ".Merge").GetHashCode();

            // Get the qualifier fields
            if (Qualifiers != null) // Much faster than Qualifers?.<Methods|Properties>
            {
                Qualifiers.ToList().ForEach(field =>
                {
                    hashCode += field.GetHashCode();
                });
            }

            // Set back the hash code value
            m_hashCode = hashCode;

            // Return the actual value
            return hashCode;
        }

        /// <summary>
        /// Compares the <see cref="MergeRequest"/> object equality against the given target object.
        /// </summary>
        /// <param name="obj">The object to be compared to the current object.</param>
        /// <returns>True if the instances are equals.</returns>
        public override bool Equals(object obj)
        {
            return GetHashCode() == obj?.GetHashCode();
        }

        /// <summary>
        /// Compares the <see cref="MergeRequest"/> object equality against the given target object.
        /// </summary>
        /// <param name="other">The object to be compared to the current object.</param>
        /// <returns>True if the instances are equal.</returns>
        public bool Equals(MergeRequest other)
        {
            return GetHashCode() == other?.GetHashCode();
        }

        /// <summary>
        /// Compares the equality of the two <see cref="MergeRequest"/> objects.
        /// </summary>
        /// <param name="objA">The first <see cref="MergeRequest"/> object.</param>
        /// <param name="objB">The second <see cref="MergeRequest"/> object.</param>
        /// <returns>True if the instances are equal.</returns>
        public static bool operator ==(MergeRequest objA, MergeRequest objB)
        {
            if (ReferenceEquals(null, objA))
            {
                return ReferenceEquals(null, objB);
            }
            return objA?.GetHashCode() == objB?.GetHashCode();
        }

        /// <summary>
        /// Compares the inequality of the two <see cref="MergeRequest"/> objects.
        /// </summary>
        /// <param name="objA">The first <see cref="MergeRequest"/> object.</param>
        /// <param name="objB">The second <see cref="MergeRequest"/> object.</param>
        /// <returns>True if the instances are not equal.</returns>
        public static bool operator !=(MergeRequest objA, MergeRequest objB)
        {
            return (objA == objB) == false;
        }
    }
}
