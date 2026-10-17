
using System;
using ApplicationClassLibrary;

namespace MunicipalityApplicationSystem
{
    public class AvlRequestTree
    {
        private class Node
        {
            public ServiceRequest Value;
            public Node Left;
            public Node Right;
            public int Height = 1;

            public Node(ServiceRequest value)
            {
                Value = value;
            }
        }

        private Node root;

        private int Height(Node node) =>
            node == null ? 0 : node.Height;

        private int Balance(Node node) =>
            node == null ? 0 : Height(node.Left) - Height(node.Right);

        private Node RotateRight(Node y)
        {
            Node x = y.Left;
            Node temp = x.Right;

            x.Right = y;
            y.Left = temp;

            y.Height = 1 + Math.Max(Height(y.Left), Height(y.Right));
            x.Height = 1 + Math.Max(Height(x.Left), Height(x.Right));

            return x;
        }

        private Node RotateLeft(Node x)
        {
            Node y = x.Right;
            Node temp = y.Left;

            y.Left = x;
            x.Right = temp;

            x.Height = 1 + Math.Max(Height(x.Left), Height(x.Right));
            y.Height = 1 + Math.Max(Height(y.Left), Height(y.Right));

            return y;
        }

        public void Insert(ServiceRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            root = InsertNode(root, request);
        }

        private Node InsertNode(Node node, ServiceRequest request)
        {
            if (node == null)
                return new Node(request);

            int comparison = string.Compare(
                request.RequestId,
                node.Value.RequestId,
                StringComparison.OrdinalIgnoreCase);

            if (comparison < 0)
                node.Left = InsertNode(node.Left, request);
            else if (comparison > 0)
                node.Right = InsertNode(node.Right, request);
            else
                return node;

            node.Height = 1 + Math.Max(
                Height(node.Left), Height(node.Right));

            int balance = Balance(node);

            if (balance > 1 &&
                string.Compare(request.RequestId,
                    node.Left.Value.RequestId,
                    StringComparison.OrdinalIgnoreCase) < 0)
                return RotateRight(node);

            if (balance < -1 &&
                string.Compare(request.RequestId,
                    node.Right.Value.RequestId,
                    StringComparison.OrdinalIgnoreCase) > 0)
                return RotateLeft(node);

            if (balance > 1 &&
                string.Compare(request.RequestId,
                    node.Left.Value.RequestId,
                    StringComparison.OrdinalIgnoreCase) > 0)
            {
                node.Left = RotateLeft(node.Left);
                return RotateRight(node);
            }

            if (balance < -1 &&
                string.Compare(request.RequestId,
                    node.Right.Value.RequestId,
                    StringComparison.OrdinalIgnoreCase) < 0)
            {
                node.Right = RotateRight(node.Right);
                return RotateLeft(node);
            }

            return node;
        }

        public ServiceRequest Search(string requestId)
        {
            Node current = root;

            while (current != null)
            {
                int comparison = string.Compare(
                    requestId, current.Value.RequestId,
                    StringComparison.OrdinalIgnoreCase);

                if (comparison == 0)
                    return current.Value;

                current = comparison < 0
                    ? current.Left : current.Right;
            }

            return null;
        }
    }
}
