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