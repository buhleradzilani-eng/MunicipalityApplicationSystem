
using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationClassLibrary;

namespace MunicipalityApplicationSystem
{
    public class ServiceRequestManager
    {
        private readonly Dictionary<string, ServiceRequest> requests =
            new Dictionary<string, ServiceRequest>(
                StringComparer.OrdinalIgnoreCase);

        private readonly AvlRequestTree avlTree = new AvlRequestTree();
        // BST index: Request ID -> request
        private class Node
        {
            public string Key;
            public ServiceRequest Value;
            public Node Left;
            public Node Right;

            public Node(ServiceRequest request)
            {
                Key = request.RequestId;
                Value = request;
            }
        }

        private Node root;

        // Red-black tree: SortedSet uses a balanced tree internally.
        private readonly SortedSet<ServiceRequest> orderedRequests =
            new SortedSet<ServiceRequest>(
                Comparer<ServiceRequest>.Create((a, b) =>
                {
                    if (ReferenceEquals(a, b)) return 0;
                    if (a == null) return -1;
                    if (b == null) return 1;

                    int result = string.Compare(
                        a.RequestId, b.RequestId,
                        StringComparison.OrdinalIgnoreCase);

                    return result != 0 ? result :
                        a.GetHashCode().CompareTo(b.GetHashCode());
                }));

        // Graph: request ID -> connected request IDs
        private readonly Dictionary<string, List<string>> graph =
            new Dictionary<string, List<string>>(
                StringComparer.OrdinalIgnoreCase);

        public IReadOnlyCollection<ServiceRequest> AllRequests =>
            requests.Values.ToList().AsReadOnly();

        public void Add(ServiceRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (string.IsNullOrWhiteSpace(request.RequestId))
                throw new ArgumentException("Request ID is required.");

            if (requests.ContainsKey(request.RequestId))
                throw new InvalidOperationException(
                    "A request with this ID already exists.");

            avlTree.Insert(request);
            requests.Add(request.RequestId, request);
            root = InsertBst(root, request);
            orderedRequests.Add(request);
            graph[request.RequestId] = new List<string>();
        }

        private Node InsertBst(Node node, ServiceRequest request)
        {
            if (node == null)
                return new Node(request);

            int comparison = string.Compare(
                request.RequestId, node.Key,
                StringComparison.OrdinalIgnoreCase);

            if (comparison < 0)
                node.Left = InsertBst(node.Left, request);
            else if (comparison > 0)
                node.Right = InsertBst(node.Right, request);

            return node;
        }

        public ServiceRequest Find(string requestId)
        {
            if (string.IsNullOrWhiteSpace(requestId))
                return null;

            Node current = root;

            while (current != null)
            {
                int comparison = string.Compare(
                    requestId, current.Key,
                    StringComparison.OrdinalIgnoreCase);

                if (comparison == 0)
                    return current.Value;

                current = comparison < 0
                    ? current.Left : current.Right;
            }

            return null;
        }

        public List<ServiceRequest> GetAll()
        {
            return requests.Values
                .OrderByDescending(r => r.DateSubmitted)
                .ToList();
        }

        public List<ServiceRequest> GetByStatus(string status)
        {
            return requests.Values
                .Where(r => string.Equals(
                    r.Status, status,
                    StringComparison.OrdinalIgnoreCase))
                .OrderByDescending(r => r.DateSubmitted)
                .ToList();
        }

        public void UpdateStatus(string requestId, string status)
        {
            ServiceRequest request = Find(requestId);

            if (request == null)
                throw new KeyNotFoundException("Request not found.");

            request.UpdateStatus(status);
        }

        // Connect two related requests in an undirected graph.
        public void ConnectRequests(string firstId, string secondId)
        {
            if (!requests.ContainsKey(firstId) ||
                !requests.ContainsKey(secondId))
                throw new KeyNotFoundException(
                    "Both requests must exist before connecting them.");

            if (firstId.Equals(secondId,
                StringComparison.OrdinalIgnoreCase))
                return;

            if (!graph[firstId].Contains(secondId))
                graph[firstId].Add(secondId);

            if (!graph[secondId].Contains(firstId))
                graph[secondId].Add(firstId);
        }

        // Breadth-first traversal of the request relationship graph.
        public List<string> TraverseGraph(string startId)
        {
            var visited = new HashSet<string>(
                StringComparer.OrdinalIgnoreCase);
            var result = new List<string>();
            var queue = new Queue<string>();

            if (!graph.ContainsKey(startId))
                return result;

            visited.Add(startId);
            queue.Enqueue(startId);

            while (queue.Count > 0)
            {
                string current = queue.Dequeue();
                result.Add(current);

                foreach (string neighbour in graph[current])
                {
                    if (visited.Add(neighbour))
                        queue.Enqueue(neighbour);
                }
            }

            return result;
        }

        // Prim's minimum spanning tree over connected requests.
        // Each graph edge has a cost of 1 for demonstration purposes.
        public List<string> MinimumSpanningTree(string startId)
        {
            var result = new List<string>();

            if (!graph.ContainsKey(startId))
                return result;

            var visited = new HashSet<string>(
                StringComparer.OrdinalIgnoreCase);
            var edges = new PriorityQueue<(string From, string To), int>();

            visited.Add(startId);

            foreach (string next in graph[startId])
                edges.Enqueue((startId, next), 1);

            while (edges.Count > 0)
            {
                var edge = edges.Dequeue();

                if (!visited.Add(edge.To))
                    continue;

                result.Add($"{edge.From} -> {edge.To}");

                foreach (string next in graph[edge.To])
                {
                    if (!visited.Contains(next))
                        edges.Enqueue((edge.To, next), 1);
                }
            }

            return result;
        }
    }
}
