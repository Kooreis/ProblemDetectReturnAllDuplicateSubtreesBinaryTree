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