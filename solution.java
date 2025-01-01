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