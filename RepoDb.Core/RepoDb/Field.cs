﻿using System.Collections.Generic;
using System.Linq;
using System;
using System.Linq.Expressions;
using RepoDb.Extensions;
using RepoDb.Exceptions;
using System.Reflection;

namespace RepoDb
{
    /// <summary>
    /// An object that signifies as data field in the query statement.
    /// </summary>
    public class Field : IEquatable<Field>
    {
        /// <summary>
        /// Creates a new instance of <see cref="Field"/> object.
        /// </summary>
        /// <param name="name">The name of the field.</param>
        public Field(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets the name of the field.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Stringify the current field object.
        /// </summary>
        /// <returns>The string value equivalent to the name of the field.</returns>
        public override string ToString()
        {
            return Name.AsQuoted();
        }

        /// <summary>
        /// Creates an enumerable of <see cref="Field"/> objects that derived from the given array of string values.
        /// </summary>
        /// <param name="fields">The array of string values that signifies the name of the fields (for each item).</param>
        /// <returns>An enumerable of <see cref="Field"/> object.</returns>
        public static IEnumerable<Field> From(params string[] fields)
        {
            if (fields == null)
            {
                throw new NullReferenceException($"List of fields must not be null.");
            }
            if (fields.Any(field => string.IsNullOrEmpty(field?.Trim())))
            {
                throw new NullReferenceException($"Field name must not be null.");
            }
            return fields.Select(field => new Field(field));
        }

        /// <summary>
        /// Parses a property from the data entity object based on the given <see cref="Expression"/> and converts the result to <see cref="Field"/> object.
        /// </summary>
        /// <typeparam name="TEntity">The type of the data entity that contains the property to be parsed.</typeparam>
        /// <param name="expression">The expression to be parsed.</param>
        /// <returns>An instance of <see cref="Field"/> object.</returns>
        public static Field Parse<TEntity>(Expression<Func<TEntity, object>> expression) where TEntity : class
        {
            if (expression.Body.IsUnary())
            {
                var unary = expression.Body.ToUnary();
                if (unary.Operand.IsMember())
                {
                    return new Field(unary.Operand.ToMember().Member.Name);
                }
                else if (unary.Operand.IsBinary())
                {
                    return new Field(unary.Operand.ToBinary().GetName());
                }
            }
            if (expression.Body.IsMember())
            {
                return new Field(expression.Body.ToMember().Member.Name);
            }
            if (expression.Body.IsBinary())
            {
                return new Field(expression.Body.ToBinary().GetName());
            }
            throw new InvalidQueryExpressionException($"Expression '{expression.ToString()}' is invalid.");
        }

        /// <summary>
        /// Parse an object and creates an enumerable of <see cref="Field"/> objects. Each field is equivalent
        /// to each property of the given object. The parse operation uses a reflection operation.
        /// </summary>
        /// <param name="obj">An object to be parsed.</param>
        /// <returns>An enumerable of <see cref="Field"/> objects.</returns>
        public static IEnumerable<Field> Parse(object obj)
        {
            if (obj == null)
            {
                throw new NullReferenceException("Parameter 'obj' cannot be null.");
            }
            if (obj.GetType().GetTypeInfo().IsGenericType == false)
            {
                throw new InvalidOperationException("Parameter 'obj' must be dynamic type.");
            }
            var properties = obj.GetType().GetTypeInfo().GetProperties();
            if (properties?.Any() == false)
            {
                throw new InvalidOperationException("Parameter 'obj' must have atleast one property.");
            }
            return properties.Select(property => new Field(PropertyMappedNameCache.Get(property)));
        }

        // Equality and comparers

        /// <summary>
        /// Returns the hashcode for this <see cref="Field"/>.
        /// </summary>
        /// <returns>The hashcode value.</returns>
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        /// <summary>
        /// Compares the <see cref="Field"/> object equality against the given target object.
        /// </summary>
        /// <param name="obj">The object to be compared to the current object.</param>
        /// <returns>True if the instances are equals.</returns>
        public override bool Equals(object obj)
        {
            return GetHashCode() == obj?.GetHashCode();
        }

        /// <summary>
        /// Compares the <see cref="Field"/> object equality against the given target object.
        /// </summary>
        /// <param name="other">The object to be compared to the current object.</param>
        /// <returns>True if the instances are equal.</returns>
        public bool Equals(Field other)
        {
            return GetHashCode() == other?.GetHashCode();
        }

        /// <summary>
        /// Compares the equality of the two <see cref="Field"/> objects.
        /// </summary>
        /// <param name="objA">The first <see cref="Field"/> object.</param>
        /// <param name="objB">The second <see cref="Field"/> object.</param>
        /// <returns>True if the instances are equal.</returns>
        public static bool operator ==(Field objA, Field objB)
        {
            if (ReferenceEquals(null, objA))
            {
                return ReferenceEquals(null, objB);
            }
            return objA?.GetHashCode() == objB?.GetHashCode();
        }

        /// <summary>
        /// Compares the inequality of the two <see cref="Field"/> objects.
        /// </summary>
        /// <param name="objA">The first <see cref="Field"/> object.</param>
        /// <param name="objB">The second <see cref="Field"/> object.</param>
        /// <returns>True if the instances are not equal.</returns>
        public static bool operator !=(Field objA, Field objB)
        {
            return (objA == objB) == false;
        }
    }
}
