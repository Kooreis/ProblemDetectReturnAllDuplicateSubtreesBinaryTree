Here is a Python solution for the problem:

```python
class Node:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

def findDuplicateSubtrees(root):
    count = {}
    ans = []
    collect(root, count, ans)
    return ans

def collect(node, count, ans):
    if not node: return "#"
    serial = "{},{},{}".format(node.val, collect(node.left, count, ans), collect(node.right, count, ans))
    count[serial] = count.get(serial, 0) + 1
    if count[serial] == 2:
        ans.append(node)
    return serial

def print_tree(node):
    if node is not None:
        print_tree(node.left)
        print(node.val)
        print_tree(node.right)

if __name__ == "__main__":
    root = Node(1)
    root.left = Node(2)
    root.right = Node(3)
    root.left.left = Node(4)
    root.right.left = Node(2)
    root.right.right = Node(4)
    root.right.left.left = Node(4)

    duplicates = findDuplicateSubtrees(root)
    for duplicate in duplicates:
        print_tree(duplicate)
        print("----")
```

This script creates a binary tree and then finds and prints all duplicate subtrees. The `findDuplicateSubtrees` function uses a dictionary to count the occurrences of each subtree. The `collect` function serializes each subtree into a string and checks if it has been seen before. If a subtree has been seen twice, it is added to the answer list. The `print_tree` function is used to print the duplicate subtrees.