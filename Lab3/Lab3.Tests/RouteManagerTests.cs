namespace Lab3.Tests
{
    [TestFixture]
    public class RouteManagerTests
    {
        [Test]
        public void GetTourOrder_ValidRoutes_ReturnsCorrectOrder()
        {
            // Arrange
            var manager = new RouteManager(3);
            manager.AddRoute(new List<int> { 1, 2 });
            manager.AddRoute(new List<int> { 2, 3 });

            // Act
            var result = manager.GetTourOrder();
            Console.WriteLine("Result: ");
            result.ForEach(x => Console.Write($"{x} "));

            // Assert
            Assert.That(result, Is.EqualTo(new List<int> { 1, 2, 3 }));
        }

        [Test]
        public void GetTourOrder_CycleInRoutes_ReturnsNull()
        {
            // Arrange
            var manager = new RouteManager(3);
            manager.AddRoute(new List<int> { 1, 2 });
            manager.AddRoute(new List<int> { 2, 3 });
            manager.AddRoute(new List<int> { 3, 1 }); // Forms a cycle

            // Act
            var result = manager.GetTourOrder();

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void GetTourOrder_DisconnectedRoutes_ReturnsCorrectPartialOrder()
        {
            // Arrange
            var manager = new RouteManager(4);
            manager.AddRoute(new List<int> { 1, 2 });
            manager.AddRoute(new List<int> { 3, 4 });

            // Act
            var result = manager.GetTourOrder();

            Console.WriteLine("Result: ");
            result.ForEach(x => Console.Write($"{x} "));

            // Assert
            CollectionAssert.AreEquivalent(new List<int> { 1, 2, 3, 4 }, result);
        }
    }
}
