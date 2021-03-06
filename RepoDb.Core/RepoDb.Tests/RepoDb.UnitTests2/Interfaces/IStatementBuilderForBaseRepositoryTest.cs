﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using RepoDb.Attributes;
using RepoDb.Interfaces;
using RepoDb.UnitTests.CustomObjects;
using System.Collections.Generic;

namespace RepoDb.UnitTests.Interfaces
{
    [TestClass]
    public class IStatementBuilderForBaseRepositoryTest
    {
        public class StatementBuilderEntity
        {
            [Primary, Identity]
            public int Id { get; set; }
            public string Name { get; set; }
        }

        // CreateBatchQuery

        [TestMethod]
        public void TestCreateBatchQuery()
        {
            // Prepare
            var statementBuilder = new Mock<IStatementBuilder>();
            var repository = new Mock<BaseRepository<StatementBuilderEntity, CustomDbConnection>>("ConnectionString", statementBuilder.Object);

            // Setup
            statementBuilder.Setup(builder =>
                builder.CreateBatchQuery<StatementBuilderEntity>(
                    It.IsAny<QueryBuilder<StatementBuilderEntity>>(),
                    It.IsAny<QueryGroup>(),
                    It.IsAny<int>(),
                    It.IsAny<int>(),
                    It.IsAny<IEnumerable<OrderField>>()));

            // Act
            repository.Object.BatchQuery(0, 10, null, null);

            // Assert
            statementBuilder.Verify(builder =>
                builder.CreateBatchQuery<StatementBuilderEntity>(
                    It.IsAny<QueryBuilder<StatementBuilderEntity>>(),
                    It.IsAny<QueryGroup>(),
                    It.IsAny<int>(),
                    It.IsAny<int>(),
                    It.IsAny<IEnumerable<OrderField>>()), Times.Once);
        }

        // CreateCount

        [TestMethod]
        public void TestCreateCount()
        {
            // Prepare
            var statementBuilder = new Mock<IStatementBuilder>();
            var repository = new Mock<BaseRepository<StatementBuilderEntity, CustomDbConnection>>("ConnectionString", statementBuilder.Object);

            // Setup
            statementBuilder.Setup(builder =>
                builder.CreateCount<StatementBuilderEntity>(
                    It.IsAny<QueryBuilder<StatementBuilderEntity>>(),
                    It.IsAny<QueryGroup>()));

            // Act
            repository.Object.Count();

            // Assert
            statementBuilder.Verify(builder =>
                builder.CreateCount<StatementBuilderEntity>(
                    It.IsAny<QueryBuilder<StatementBuilderEntity>>(),
                    It.IsAny<QueryGroup>()), Times.Once);
        }

        // CreateDelete

        [TestMethod]
        public void TestCreateDelete()
        {
            // Prepare
            var statementBuilder = new Mock<IStatementBuilder>();
            var repository = new Mock<BaseRepository<StatementBuilderEntity, CustomDbConnection>>("ConnectionString", statementBuilder.Object);

            // Setup
            statementBuilder.Setup(builder =>
                builder.CreateDelete<StatementBuilderEntity>(
                    It.IsAny<QueryBuilder<StatementBuilderEntity>>(),
                    It.IsAny<QueryGroup>()));

            // Act
            repository.Object.Delete();

            // Assert
            statementBuilder.Verify(builder =>
                builder.CreateDelete<StatementBuilderEntity>(
                    It.IsAny<QueryBuilder<StatementBuilderEntity>>(),
                    It.IsAny<QueryGroup>()), Times.Once);
        }

        // CreateDeleteAll

        [TestMethod]
        public void TestCreateDeleteAll()
        {
            // Prepare
            var statementBuilder = new Mock<IStatementBuilder>();
            var repository = new Mock<BaseRepository<StatementBuilderEntity, CustomDbConnection>>("ConnectionString", statementBuilder.Object);

            // Setup
            statementBuilder.Setup(builder =>
                builder.CreateDeleteAll<StatementBuilderEntity>(
                    It.IsAny<QueryBuilder<StatementBuilderEntity>>()));

            // Act
            repository.Object.DeleteAll();

            // Assert
            statementBuilder.Verify(builder =>
                builder.CreateDeleteAll<StatementBuilderEntity>(
                    It.IsAny<QueryBuilder<StatementBuilderEntity>>()), Times.Once);
        }

        // CreateInlineInsert

        [TestMethod]
        public void TestCreateInlineInsert()
        {
            // Prepare
            var statementBuilder = new Mock<IStatementBuilder>();
            var repository = new Mock<BaseRepository<StatementBuilderEntity, CustomDbConnection>>("ConnectionString", statementBuilder.Object);

            // Setup
            statementBuilder.Setup(builder =>
                builder.CreateInlineInsert<StatementBuilderEntity>(
                    It.IsAny<QueryBuilder<StatementBuilderEntity>>(),
                    It.IsAny<IEnumerable<Field>>(),
                    It.IsAny<bool>()));

            // Act
            repository.Object.InlineInsert(new { Id = 1 });

            // Assert
            statementBuilder.Verify(builder =>
                builder.CreateInlineInsert<StatementBuilderEntity>(
                    It.IsAny<QueryBuilder<StatementBuilderEntity>>(),
                    It.IsAny<IEnumerable<Field>>(),
                    It.IsAny<bool>()), Times.Once);
        }

        // CreateInlineMerge

        [TestMethod]
        public void TestCreateInlineMerge()
        {
            // Prepare
            var statementBuilder = new Mock<IStatementBuilder>();
            var repository = new Mock<BaseRepository<StatementBuilderEntity, CustomDbConnection>>("ConnectionString", statementBuilder.Object);

            // Setup
            statementBuilder.Setup(builder =>
                builder.CreateInlineMerge<StatementBuilderEntity>(
                    It.IsAny<QueryBuilder<StatementBuilderEntity>>(),
                    It.IsAny<IEnumerable<Field>>(),
                    It.IsAny<IEnumerable<Field>>(),
                    It.IsAny<bool>()));

            // Act
            repository.Object.InlineMerge(new { Id = 1, Name = "Name" });

            // Assert
            statementBuilder.Verify(builder =>
                builder.CreateInlineMerge<StatementBuilderEntity>(
                    It.IsAny<QueryBuilder<StatementBuilderEntity>>(),
                    It.IsAny<IEnumerable<Field>>(),
                    It.IsAny<IEnumerable<Field>>(),
                    It.IsAny<bool>()), Times.Once);
        }

        // CreateInlineUpdate

        [TestMethod]
        public void TestCreateInlineUpdate()
        {
            // Prepare
            var statementBuilder = new Mock<IStatementBuilder>();
            var repository = new Mock<BaseRepository<StatementBuilderEntity, CustomDbConnection>>("ConnectionString", statementBuilder.Object);

            // Setup
            statementBuilder.Setup(builder =>
                builder.CreateInlineUpdate<StatementBuilderEntity>(
                    It.IsAny<QueryBuilder<StatementBuilderEntity>>(),
                    It.IsAny<IEnumerable<Field>>(),
                    It.IsAny<QueryGroup>(),
                    It.IsAny<bool>()));

            // Act
            repository.Object.InlineUpdate(new { Name = "Name" }, new { Id = 1 });

            // Assert
            statementBuilder.Verify(builder =>
                builder.CreateInlineUpdate<StatementBuilderEntity>(
                    It.IsAny<QueryBuilder<StatementBuilderEntity>>(),
                    It.IsAny<IEnumerable<Field>>(),
                    It.IsAny<QueryGroup>(),
                    It.IsAny<bool>()), Times.Once);
        }

        // CreateInsert

        [TestMethod]
        public void TestCreateInsert()
        {
            // Prepare
            var statementBuilder = new Mock<IStatementBuilder>();
            var repository = new Mock<BaseRepository<StatementBuilderEntity, CustomDbConnection>>("ConnectionString", statementBuilder.Object);

            // Setup
            statementBuilder.Setup(builder =>
                builder.CreateInsert<StatementBuilderEntity>(
                    It.IsAny<QueryBuilder<StatementBuilderEntity>>()));

            // Act
            repository.Object.Insert(new StatementBuilderEntity { Name = "Name" });

            // Assert
            statementBuilder.Verify(builder =>
                builder.CreateInsert<StatementBuilderEntity>(
                    It.IsAny<QueryBuilder<StatementBuilderEntity>>()), Times.Once);
        }

        // CreateMerge

        [TestMethod]
        public void TestCreateMerge()
        {
            // Prepare
            var statementBuilder = new Mock<IStatementBuilder>();
            var repository = new Mock<BaseRepository<StatementBuilderEntity, CustomDbConnection>>("ConnectionString", statementBuilder.Object);

            // Setup
            statementBuilder.Setup(builder =>
                builder.CreateMerge<StatementBuilderEntity>(
                    It.IsAny<QueryBuilder<StatementBuilderEntity>>(),
                    It.IsAny<IEnumerable<Field>>()));

            // Act
            repository.Object.Merge(new StatementBuilderEntity { Id = 1, Name = "Name" });

            // Assert
            statementBuilder.Verify(builder =>
                builder.CreateMerge<StatementBuilderEntity>(
                    It.IsAny<QueryBuilder<StatementBuilderEntity>>(),
                    It.IsAny<IEnumerable<Field>>()), Times.Once);
        }

        // CreateQuery

        [TestMethod]
        public void TestCreateQuery()
        {
            // Prepare
            var statementBuilder = new Mock<IStatementBuilder>();
            var repository = new Mock<BaseRepository<StatementBuilderEntity, CustomDbConnection>>("ConnectionString", statementBuilder.Object);

            // Setup
            statementBuilder.Setup(builder =>
                builder.CreateQuery<StatementBuilderEntity>(
                    It.IsAny<QueryBuilder<StatementBuilderEntity>>(),
                    It.IsAny<QueryGroup>(),
                    It.IsAny<IEnumerable<OrderField>>(),
                    It.IsAny<int>()));

            // Act
            repository.Object.Query(new StatementBuilderEntity { Id = 1, Name = "Name" });

            // Assert
            statementBuilder.Verify(builder =>
                builder.CreateQuery<StatementBuilderEntity>(
                    It.IsAny<QueryBuilder<StatementBuilderEntity>>(),
                    It.IsAny<QueryGroup>(),
                    It.IsAny<IEnumerable<OrderField>>(),
                    It.IsAny<int>()), Times.Once);
        }

        // CreateTruncate

        [TestMethod]
        public void TestCreateTruncate()
        {
            // Prepare
            var statementBuilder = new Mock<IStatementBuilder>();
            var repository = new Mock<BaseRepository<StatementBuilderEntity, CustomDbConnection>>("ConnectionString", statementBuilder.Object);

            // Setup
            statementBuilder.Setup(builder =>
                builder.CreateTruncate<StatementBuilderEntity>(
                    It.IsAny<QueryBuilder<StatementBuilderEntity>>()));

            // Act
            repository.Object.Truncate();

            // Assert
            statementBuilder.Verify(builder =>
                builder.CreateTruncate<StatementBuilderEntity>(
                    It.IsAny<QueryBuilder<StatementBuilderEntity>>()), Times.Once);
        }

        // CreateUpdate

        [TestMethod]
        public void TestCreateUpdate()
        {
            // Prepare
            var statementBuilder = new Mock<IStatementBuilder>();
            var repository = new Mock<BaseRepository<StatementBuilderEntity, CustomDbConnection>>("ConnectionString", statementBuilder.Object);

            // Setup
            statementBuilder.Setup(builder =>
                builder.CreateUpdate<StatementBuilderEntity>(
                    It.IsAny<QueryBuilder<StatementBuilderEntity>>(),
                    It.IsAny<QueryGroup>()));

            // Act
            repository.Object.Update(new StatementBuilderEntity { Id = 1, Name = "Update" });

            // Assert
            statementBuilder.Verify(builder =>
                builder.CreateUpdate<StatementBuilderEntity>(
                    It.IsAny<QueryBuilder<StatementBuilderEntity>>(),
                    It.IsAny<QueryGroup>()), Times.Once);
        }
    }
}
