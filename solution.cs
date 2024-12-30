Here is a C# console application that solves the problem:

```csharp
using System;
using System.Collections.Generic;

public class Node
{
    public int data;
    public Node left, right;
    public Node(int item)
    {
        data = item;
        left = right = null;
    }
}

public class BinaryTree
{
    Dictionary<string, int> subtrees = new Dictionary<string, int>();
    List<Node> duplicates = new List<Node>();

    public List<Node> FindDuplicateSubtrees(Node node)
    {
        subtrees.Clear();
        duplicates.Clear();
        PostOrder(node);
        return duplicates;
    }

    string PostOrder(Node node)
    {
        if (node == null)
            return "";

        string str = "(";
        str += PostOrder(node.left);
        str += node.data;
        str += PostOrder(node.right);
        str += ")";

        if (subtrees.ContainsKey(str) && subtrees[str] == 1)
            duplicates.Add(node);

        if (!subtrees.ContainsKey(str))
            subtrees[str] = 1;
        else
            subtrees[str]++;

        return str;
    }
}

class Program
{
    static void Main(string[] args)
    {
        BinaryTree tree = new BinaryTree();
        Node root = new Node(1);
        root.left = new Node(2);
        root.right = new Node(3);
        root.left.left = new Node(4);
        root.right.left = new Node(2);
        root.right.left.left = new Node(4);
        root.right.right = new Node(4);
        List<Node> duplicates = tree.FindDuplicateSubtrees(root);

        foreach (var duplicate in duplicates)
        {
            Console.WriteLine(duplicate.data);
        }
    }
}
```

This program creates a binary tree and then finds all duplicate subtrees in it. The `FindDuplicateSubtrees` method uses a post-order traversal to create a string representation of each subtree in the binary tree and stores these strings in a dictionary. If a string representation is already in the dictionary, it means that the subtree is a duplicate, so the root node of the subtree is added to the list of duplicates. The list of duplicates is then returned.