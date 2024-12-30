Here is a Java console application that solves the problem:

```java
import java.util.*;

class Node {
    int data;
    Node left, right;
    Node(int data) {
        this.data = data;
        left = right = null;
    }
}

class Main {
    static Map<String, Integer> m;
    static List<Node> dups;

    public static void main(String args[]) {
        Node root = new Node(1);
        root.left = new Node(2);
        root.left.left = new Node(4);
        root.right = new Node(3);
        root.right.left = new Node(2);
        root.right.left.left = new Node(4);
        root.right.right = new Node(4);
        m = new HashMap<>();
        dups = new ArrayList<>();
        inorder(root);
        for (Node node : dups) {
            System.out.println(node.data);
        }
    }

    static String inorder(Node node) {
        if (node == null) {
            return "";
        }
        String str = "(";
        str += inorder(node.left);
        str += Integer.toString(node.data);
        str += inorder(node.right);
        str += ")";
        if (m.get(str) != null && m.get(str) == 1) {
            dups.add(node);
        }
        if (m.containsKey(str)) {
            m.put(str, m.get(str) + 1);
        } else {
            m.put(str, 1);
        }
        return str;
    }
}
```

This program creates a binary tree and then finds all duplicate subtrees in it. The duplicate subtrees are then printed to the console. The `inorder` function is used to generate a unique string representation for each subtree in the binary tree. This string is then stored in a map along with its frequency. If the frequency of a string is more than 1, it means that the subtree is a duplicate.