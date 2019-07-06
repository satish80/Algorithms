using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuccessAlgorithms
{
    public class Graph
    {
        public void DFSTraverse()
        {
            DirectedGraph g = new DirectedGraph(6);
            g.AddEdge(0, 1);
            g.AddEdge(1, 2);
            g.AddEdge(2, 3);
            g.AddEdge(3, 4);
            DFSTraverse(g);
        }

        private void DFSTraverse(DirectedGraph graph)
        {
            for(int idx = 0; idx < graph.AdjList.Count; idx ++)
            {
                if (!graph.Visited[idx])
                {
                    DFSTraverseRecurse(graph, idx);
                }
            }
        }

        private void DFSTraverseRecurse(DirectedGraph graph, int vertex)
        {
            graph.Visited[vertex] = true;

            Console.WriteLine($"Visiting graph node {vertex}");

            var adjList = graph.AdjList.ContainsKey(vertex) ? graph.AdjList[vertex] : null;
            if (adjList != null)
            {
                foreach (int adjVertex in adjList)
                {
                    if (!graph.Visited[adjVertex])
                    {
                        DFSTraverseRecurse(graph, adjVertex);
                    }
                }
            }
        }

        public void BFS()
        {
            DirectedGraph g = new DirectedGraph(6);
            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(1, 2);
            g.AddEdge(2, 0);
            g.AddEdge(2, 3);
            g.AddEdge(3, 3);

            BFSTraverse(g, 2);
        }

        private void BFSTraverse(DirectedGraph graph, int vertex)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(vertex);

            while(queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (graph.Visited[node])
                {
                    continue;
                }

                graph.Visited[node] = true;

                Console.WriteLine($"visiting node {node}");
                var adjList = graph.AdjList.ContainsKey(node) ? graph.AdjList[node] : null;

                if (adjList != null)
                {
                    foreach (int adjVertex in graph.AdjList[node])
                    {
                        if (!graph.Visited[adjVertex])
                        {
                            queue.Enqueue(adjVertex);
                        }
                    }
                }
            }
        }

        public void IsCyclic()
        {
            DirectedGraph g = new DirectedGraph(4);
            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            //g.AddEdge(1, 2);
            // g.AddEdge(2, 0);
            g.AddEdge(2, 3);
            // g.AddEdge(3, 3);

            bool[] visited = new bool[4];
            bool[] visitedStack = new bool[4];
            Console.WriteLine(IsCyclic(g, 0, visited, ref visitedStack));
        }

        private bool IsCyclic(DirectedGraph graph, int vertex, bool[] visited, ref bool[] VisitedStack)
        {
            if (!visited[vertex])
            {
                visited[vertex] = true;
                VisitedStack[vertex] = true;

                var list = graph.AdjList.ContainsKey(vertex) ? graph.AdjList[vertex] : null;
                if (list != null)
                {
                    foreach (int neighbor in list)
                    {
                        if (!visited[neighbor] && IsCyclic(graph, neighbor, visited, ref VisitedStack))
                        {
                            return true;
                        }
                        else if (VisitedStack[neighbor])
                        {
                            return true;
                        }
                    }
                }
            }

            VisitedStack[vertex] = false;
            return false;
        }

        public void IsUnDirectedCyclic()
        {
            UnDirectedGraph g = new UnDirectedGraph(5);
            g.AddEdge(1, 0);
            g.AddEdge(0, 2);
            g.AddEdge(2, 0);
            g.AddEdge(0, 3);
            g.AddEdge(3, 4);
            Console.WriteLine(IsUnDirectedCyclic(g));
        }

        private bool IsUnDirectedCyclic(UnDirectedGraph graph)
        {
            for(int idx = 0; idx < graph.Vertices; idx ++)
            {
                if (! graph.Visited[idx])
                {
                    if (IsUnDirectedCyclicUtil(graph, idx, -1))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool IsUnDirectedCyclicUtil(UnDirectedGraph graph, int vertex, int parent)
        {
            graph.Visited[vertex] = true;

            if (graph.AdjList.ContainsKey(vertex))
            {
                foreach(int idx in graph.AdjList[vertex])
                {
                    if (!graph.Visited[idx])
                    {
                        if (IsUnDirectedCyclicUtil(graph, idx, vertex))
                        {
                            return true;
                        }
                    }
                    else if (idx != parent)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void TopologicalSort()
        {
            DirectedGraph graph = new DirectedGraph(6);
            graph.AddEdge(5, 2);
            graph.AddEdge(5, 0);
            graph.AddEdge(4, 0);
            graph.AddEdge(4, 1);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 1);

            Stack<int> stack = new Stack<int>();

            for(int idx = 0; idx < graph.Vertices; idx ++)
            {
                if (! graph.Visited[idx])
                {
                    TopologicalSortUtil(graph, idx, stack);
                }
            }

            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }
        }

        private void TopologicalSortUtil(DirectedGraph graph, int vertex, Stack<int> stack)
        {
            graph.Visited[vertex] = true;

            if (graph.AdjList.ContainsKey(vertex))
            {
                foreach(int neighbor in graph.AdjList[vertex])
                {
                    if (! graph.Visited[neighbor])
                    {
                        TopologicalSortUtil(graph, neighbor, stack);
                    }
                }
            }
            stack.Push(vertex);
        }

        /// https://www.geeksforgeeks.org/given-sorted-dictionary-find-precedence-characters/
        public void AlienDictionary()
        {
            string[] words = { "caa", "aaa", "aab" };
            AlienDictionary(words, 3, new DirectedGraph(3));
        }

        private void AlienDictionary(string[] dict, int n, DirectedGraph graph)
        {
            for(int i = 0; i < n-1; i++)
            {
                string word1 = dict[i];
                string word2 = dict[i + 1];

                for(int j = 0; j < Math.Min(word1.Length, word2.Length); j ++)
                {
                    if (word1[j] != word2[j])
                    {
                        graph.AddEdge(word1[j] - 'a', word2[j] - 'a');
                        break;
                    }
                }
            }

            Stack<int> stack = new Stack<int>();

            for (int idx = 0; idx < graph.Vertices; idx++)
            {
                if (!graph.Visited[idx])
                {
                    TopologicalSortUtil(graph, idx, stack);
                }
            }

            while (stack.Count > 0)
            {
                Console.WriteLine((char)('a' + stack.Pop()));
            }
        }

        public void ReverseGraph()
        {
            DirectedGraph g = new DirectedGraph(4);
            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            //g.AddEdge(1, 2);
            // g.AddEdge(2, 0);
            g.AddEdge(2, 3);

            var reversedGraph = ReverseGraphUtil(g);

        }

        private DirectedGraph ReverseGraphUtil(DirectedGraph graph)
        {
            DirectedGraph reversedGraph = new DirectedGraph(graph.Vertices);

            for(int idx = 0; idx < graph.Vertices; idx ++)
            {
                if (graph.AdjList.ContainsKey(idx))
                {
                    var adjList = graph.AdjList[idx];

                    foreach(int neighbor in adjList)
                    {
                        reversedGraph.AddEdge(neighbor, idx);
                    }
                }
            }

            return reversedGraph;
        }

        public void MotherVertex()
        {
            DirectedGraph g = new DirectedGraph(7);
            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(1, 3);
            g.AddEdge(4, 1);
            g.AddEdge(6, 4);
            g.AddEdge(5, 6);
            g.AddEdge(5, 2);
            g.AddEdge(6, 0);

            Console.WriteLine(MotherVertex(g));
        }

        private int MotherVertex(DirectedGraph graph)
        {
            int v = -1;
            for (int idx = 0; idx < graph.Vertices; idx++)
            {
                if (! graph.Visited[idx])
                {
                    DFSTraverseRecurse(graph, idx);
                    v = idx;
                }
            }

            if (graph.AdjList.ContainsKey(v))
            {
                for(int idx = 0; idx < graph.Visited.Count(); idx ++)
                {
                    graph.Visited[idx] = false;
                }

                DFSTraverseRecurse(graph, v);

                for (int idx = 0; idx < graph.Visited.Count(); idx++)
                {
                    if (!graph.Visited[idx])
                    {
                        return -1;
                    }
                }
            }

            return v;
        }

        public void Itinerary()
        {
            string[,] flights = new string[,]
            {
                { "JFK", "SFO" },
                { "JFK", "ATL" },
                { "SFO", "ATL" },
                { "ATL", "JFK" },
                { "ATL", "SFO" }
            };

            var res = Itinerary(flights, "JFK");
        }

        private List<string> Itinerary(string[,] flights, string source)
        {
            Dictionary<string, List<string>> map = new Dictionary<string, List<string>>();

            for(int row = 0; row < flights.GetLength(0); row ++)
            {
                if (!map.ContainsKey(flights[row,0]))
                {
                    map.Add(flights[row, 0], new List<string>());
                }

                map[flights[row, 0]].Add(flights[row, 1]);
            }

            var list = new List<string>();
            DFSTraverseFlights(source, map, list, new HashSet<string>());
            return list;
        }

        private void DFSTraverseFlights(string source, Dictionary<string, List<string>> map, List<string> list, HashSet<string> visited)
        {
            list.Add(source);

            var destinations = map[source];
            destinations.Sort();

            while(destinations.Count > 0)
            {
                var stop = destinations.First();
                destinations.Remove(stop);
                DFSTraverseFlights(stop, map, list, visited);
            }
        }

        public void FindAttendeesInParty()
        {
            List<Person> persons = new List<Person>();
            var person2 = new Person(2, Status.No, null);
            var person8 = new Person(8, Status.No, null);
            var person6 = new Person(6, Status.Yes, null);
            var person3 = new Person(3, Status.Yes, null);
            var person4 = new Person(4, Status.Depends, new List<Person>() { person6});
            var person5 = new Person(5, Status.Depends, new List<Person>() { person3, person8 });
            var person7 = new Person(7, Status.Depends, new List<Person>() { person6 });
            var person1 = new Person(1, Status.Depends, new List<Person>() { person2, person4, person5, person8});

            persons.Add(person1);
            persons.Add(person2);
            persons.Add(person3);
            persons.Add(person4);
            persons.Add(person5);
            persons.Add(person6);
            persons.Add(person7);
            persons.Add(person8);

            var attendants = FindAttendeesInParty(persons);
        }

        private List<Person> FindAttendeesInParty(List<Person> persons)
        {
            var updatedPersons = UpdateNDependents(persons);
            List<Person> result = new List<Person>();

            foreach(Person person in persons)
            {
                if (person.Status == Status.No)
                {
                    continue;
                }

                if (person.Status == Status.Depends)
                {
                    if (!DFS(person, null))
                    {
                        continue;
                    }
                }

                result.Add(person);
            }

            return result;
        }

        private bool DFS(Person person, Person originator)
        {
            bool res = true;

            if (person.Status == Status.No)
            {
                return false;
            }

            foreach(Person p in person.Dependants)
            {
                if (p == originator)
                {
                    person.Status = Status.Yes;
                    return true;
                }

                if (p.Status == Status.Depends)
                {
                    res = DFS(p, originator);
                    if (! res)
                    {
                        person.Status = Status.No;
                        return false;
                    }
                }
            }

            return res;
        }

        private List<Person> UpdateNDependents(List<Person> persons)
        {
            HashSet<Person> personNotAttending = null;

            foreach(Person person in persons)
            {
                if (person.Status == Status.No)
                {
                    if (personNotAttending == null)
                    {
                        personNotAttending = new HashSet<Person>();
                    }

                    personNotAttending.Add(person);
                }
            }

            foreach(Person person in persons)
            {
                if (person.Dependants?.Any(p => personNotAttending.Contains(p)) == true)
                {
                    person.Status = Status.No;
                }
            }

            return persons;
        }

        public class Person
        {
            public Person(int id, Status status, List<Person> dependants)
            {
                this.Id = id;
                this.Status = status;
            }

            public Status Status
            {
                get;
                set;
            }

            public int Id;
            public List<Person> Dependants
            {
                get;
            }
        }

        public enum Status
        {
            Yes,
            No,
            Depends
        };

        // https://leetcode.com/problems/max-points-on-a-line/description/
        public void PointsOnALine()
        {
            Pair p = new Pair(1,1);
            List<Pair> list = new List<Pair>();
            list.Add(new Pair(1, 1));
            list.Add(new Pair(3, 2));
            list.Add(new Pair(5, 3));
            list.Add(new Pair(4, 1));
            list.Add(new Pair(2, 3));
            list.Add(new Pair(1, 4));

            Console.WriteLine(PointsOnALine(list));
        }

        private int PointsOnALine(List<Pair> list)
        {
            if (list.Count == 0)
            {
                return 0;
            }

            Dictionary<Pair, int> map = new Dictionary<Pair, int>();
            int value = 0;
            int max = 0;

            foreach(Pair p in list)
            {
                value = FetchLength(p, list, map);

                max = max < value ? value : max;
            }

            return max;
        }

        private int FetchLength(Pair p, List<Pair> list, Dictionary<Pair, int> map)
        {
            Queue<Pair> queue = new Queue<Pair>();
            queue.Enqueue(p);

            List<Pair> visited = new List<Pair>();

            int value = 0;
            while(queue.Count > 0)
            {
                var element = queue.Dequeue();

                if (visited.Contains(element))
                {
                    continue;
                }

                visited.Add(element);

                if (map.ContainsKey(element))
                {
                    value += map[element];
                    continue;
                }

                value++;

                Pair up = new Pair(element.X - 1, element.Y+1);
                Pair down = new Pair(element.X + 1, element.Y - 1);

                if (map.ContainsKey(up))
                {
                    value += map[up]; 
                }
                else if (list.Contains(up) && ! visited.Contains(up))
                {
                    queue.Enqueue(up);
                }

                if (map.ContainsKey(down))
                {
                    value += map[down];
                }
                else if (list.Contains(down) && !visited.Contains(down))
                {
                    queue.Enqueue(down);
                }
            }

            map[p] = value;
            return value;
        }
    }

    public class Pair : IEquatable<Pair>
    {
        public Pair(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X;
        public int Y;

        public bool Equals(Pair other)
        {
            if (this.X == other.X && this.Y == other.Y)
            {
                return true;
            }

            return false;
        }
    }

    public class DirectedGraph
    {
        public Dictionary<int, List<int>> AdjList;

        public int Vertices;

        public bool[] Visited;

        public DirectedGraph(int vertex)
        {
            this.Vertices = vertex;
            AdjList = new Dictionary<int, List<int>>(vertex);
            Visited = new bool[vertex];
        }

        public void AddEdge(int vertex, int weight)
        {
            if (AdjList == null || ! AdjList.ContainsKey(vertex))
            {
                var list = new List<int>();
                list.Add(weight);
                AdjList.Add(vertex, list);
            }
            else
            {
                AdjList[vertex].Add(weight);
            }
        }
    }

    public class UnDirectedGraph
    {
        public UnDirectedGraph(int vertices)
        {
            this.Vertices = vertices;
            this.AdjList = new Dictionary<int,List<int>>(Vertices);
            this.Visited = new bool[Vertices];
        }

        public int Vertices { get; }

        public Dictionary<int, List<int>> AdjList { get; }

        public bool[] Visited { get; }

        public void AddEdge(int vertex, int weight)
        {
            if (AdjList.ContainsKey(vertex))
            {
                AdjList[vertex].Add(weight);
            }
            else
            {
                var list = new List<int>
                {
                    weight
                };
                AdjList.Add(vertex, list);
            }

            if (AdjList.ContainsKey(weight))
            {
                AdjList[weight].Add(vertex);
            }
            else
            {
                var list = new List<int>
                {
                    vertex
                };
                AdjList.Add(weight, list);
            }
        }
    }
}
