using Lab3;
using System;
using System.Collections.Generic;
using System.IO;


// Read input from the file "input.txt"
var input = File.ReadAllLines("input.txt");

// Extract n and k from the first line
var firstLine = input[0].Split();
int n = int.Parse(firstLine[0]);
int k = int.Parse(firstLine[1]);

var routeManager = new RouteManager(n);

// Read the road matrix
for (int i = 1; i <= n; i++)
{
    string line = input[i];
    for (int j = 0; j < n; j++)
    {
        if (line[j] == '-')
        {
            routeManager.AddRoute(new List<int> { i, j + 1 });
        }
    }
}

// Read the routes
for (int i = n + 1; i < n + 1 + k; i++)
{
    var route = new List<int>();
    var cities = input[i].Substring(1).Trim().Split(); // Remove leading dot and trim
    foreach (var city in cities)
    {
        route.Add(int.Parse(city));
    }
    routeManager.AddRoute(route);
}

// Get the order of the tour
var result = routeManager.GetTourOrder();

// Output the result
if (result == null)
{
    Console.WriteLine(-1);
}
else
{
    Console.WriteLine(string.Join(" ", result));
}
