using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class RouteManager
    {
        private readonly CityGraph _graph;

        public RouteManager(int numberOfCities)
        {
            _graph = new CityGraph(numberOfCities);
        }

        public void AddRoute(List<int> route)
        {
            for (int i = 0; i < route.Count - 1; i++)
            {
                _graph.AddEdge(route[i], route[i + 1]);
            }
        }

        public List<int> GetTourOrder()
        {
            return _graph.TopologicalSort();
        }
    }
}
