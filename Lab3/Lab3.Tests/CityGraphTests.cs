using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Tests
{
    [TestFixture]
    public class CityGraphTests
    {
        [Test]
        public void TopologicalSort_NoCycle_ReturnsCorrectOrder()
        {
            // Arrange
            var graph = new CityGraph(4);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 4);

            // Act
            var result = graph.TopologicalSort();
            Console.WriteLine("Result: ");
            result.ForEach(x => Console.Write($"{x} "));

            // Assert
            Assert.That(result, Is.EqualTo(new List<int> { 1, 2, 3, 4 }));
        }

        [Test]
        public void TopologicalSort_WithCycle_ReturnsNull()
        {
            // Arrange
            var graph = new CityGraph(3);
            graph.AddEdge(1, 2);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 1); // Forms a cycle

            // Act
            var result = graph.TopologicalSort();

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void TopologicalSort_DisconnectedGraph_ReturnsCorrectPartialOrder()
        {
            // Arrange
            var graph = new CityGraph(4);
            graph.AddEdge(1, 2);
            graph.AddEdge(3, 4);

            // Act
            var result = graph.TopologicalSort();
            Console.WriteLine("Result: ");
            result.ForEach(x => Console.Write($"{x} "));

            // Assert
            // Valid results can be either [1, 2, 3, 4] or [3, 4, 1, 2]
            CollectionAssert.AreEquivalent(new List<int> { 1, 2, 3, 4 }, result);
        }

        [Test]
        public void TopologicalSort_AllNodesIndependent_ReturnsAnyOrder()
        {
            // Arrange
            var graph = new CityGraph(3);

            // Act
            var result = graph.TopologicalSort();
            Console.WriteLine("Result: ");
            result.ForEach(x => Console.Write($"{x} "));

            // Assert
            CollectionAssert.AreEquivalent(new List<int> { 1, 2, 3 }, result);
        }
    }
}
