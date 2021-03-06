﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RepoDb.UnitTests
{
    public partial class QueryGroupTest
    {
        // Operations

        [TestMethod]
        public void TestParseExpressionForEqual()
        {
            // Act
            var actual = QueryGroup.Parse<QueryGroupTestExpressionClass>(e => e.PropertyInt == 1).GetString();
            var expected = "([PropertyInt] = @PropertyInt)";

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestParseExpressionForNotEqual()
        {
            // Act
            var actual = QueryGroup.Parse<QueryGroupTestExpressionClass>(e => e.PropertyInt != 1).GetString();
            var expected = "([PropertyInt] <> @PropertyInt)";

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestParseExpressionForGreaterThan()
        {
            // Act
            var actual = QueryGroup.Parse<QueryGroupTestExpressionClass>(e => e.PropertyInt > 1).GetString();
            var expected = "([PropertyInt] > @PropertyInt)";

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestParseExpressionForGreaterThanOrEqual()
        {
            // Act
            var actual = QueryGroup.Parse<QueryGroupTestExpressionClass>(e => e.PropertyInt >= 1).GetString();
            var expected = "([PropertyInt] >= @PropertyInt)";

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestParseExpressionForLessThan()
        {
            // Act
            var actual = QueryGroup.Parse<QueryGroupTestExpressionClass>(e => e.PropertyInt < 1).GetString();
            var expected = "([PropertyInt] < @PropertyInt)";

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestParseExpressionForLessThanOrEqual()
        {
            // Act
            var actual = QueryGroup.Parse<QueryGroupTestExpressionClass>(e => e.PropertyInt <= 1).GetString();
            var expected = "([PropertyInt] <= @PropertyInt)";

            // Assert
            Assert.AreEqual(expected, actual);
        }

        // Equals Boolean

        [TestMethod]
        public void TestParseExpressionForEqualEqualsFalse()
        {
            // Act
            var actual = QueryGroup.Parse<QueryGroupTestExpressionClass>(e => (e.PropertyInt == 1) == false).GetString();
            var expected = "NOT ([PropertyInt] = @PropertyInt)";

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestParseExpressionForEqualEqualsTrue()
        {
            // Act
            var actual = QueryGroup.Parse<QueryGroupTestExpressionClass>(e => (e.PropertyInt == 1) == true).GetString();
            var expected = "([PropertyInt] = @PropertyInt)";

            // Assert
            Assert.AreEqual(expected, actual);
        }

        // ExpectedException

        [TestMethod, ExpectedException(typeof(NotSupportedException))]
        public void ThrowExceptionOnParseExpressionWithoutProperty()
        {
            QueryGroup.Parse<QueryGroupTestExpressionClass>(e => true).GetString();
        }
    }
}
