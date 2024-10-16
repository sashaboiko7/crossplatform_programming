﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    public class CityGraph
    {
        private readonly List<int>[] _adjacencyList;
        private readonly int[] _inDegrees;

        public CityGraph(int numberOfCities)
        {
            if (numberOfCities <= 0)
            {
                Console.WriteLine("The number of cities must be greater than zero.");
                return;
            }

            _adjacencyList = new List<int>[numberOfCities + 1];
            _inDegrees = new int[numberOfCities + 1];

            for (int i = 0; i <= numberOfCities; i++)
            {
                _adjacencyList[i] = new List<int>();
            }
        }

        public void AddEdge(int from, int to)
        {
            if (from <= 0 || from >= _adjacencyList.Length)
            {
                Console.WriteLine($"City {from} is out of bounds.");
                return;
            }

            if (to <= 0 || to >= _adjacencyList.Length)
            {
                Console.WriteLine($"City {to} is out of bounds.");
                return;
            }

            if (from == to)
            {
                Console.WriteLine("Self-loops are not allowed.");
                return;
            }

            _adjacencyList[from].Add(to);
            _inDegrees[to]++;

            Console.WriteLine($"Added edge: {from} -> {to}");
        }

        public List<int> TopologicalSort()
        {
            if (_adjacencyList.Length == 0)
            {
                Console.WriteLine("Graph is empty, topological sort cannot be performed.");
                return null;
            }

            var result = new List<int>();
            var queue = new Queue<int>();

            Console.WriteLine("Initial in-degrees of cities:");
            for (int i = 1; i < _inDegrees.Length; i++)
            {
                Console.WriteLine($"City {i}, in-degree: {_inDegrees[i]}");
                if (_inDegrees[i] == 0)
                {
                    queue.Enqueue(i);
                    Console.WriteLine($"City {i} added to the queue");
                }
            }

            while (queue.Count > 0)
            {
                int current = queue.Dequeue();
                result.Add(current);
                Console.WriteLine($"City {current} removed from the queue, added to result");

                foreach (var neighbor in _adjacencyList[current])
                {
                    _inDegrees[neighbor]--;
                    Console.WriteLine($"City {neighbor}, new in-degree: {_inDegrees[neighbor]}");
                    if (_inDegrees[neighbor] == 0)
                    {
                        queue.Enqueue(neighbor);
                        Console.WriteLine($"City {neighbor} added to the queue");
                    }
                }
            }

            if (result.Count == _inDegrees.Length - 1)
            {
                Console.WriteLine("Topological sort completed successfully.");
                return result;
            }
            else
            {
                Console.WriteLine("The graph contains a cycle, sorting is not possible.");
                return null;
            }
        }
    }
}
