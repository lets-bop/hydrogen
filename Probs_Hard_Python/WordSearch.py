class TrieNode:
# characters are implicitly defined by link index

    def __init__(self, is_terminal_node):
        self.is_terminal_node = is_terminal_node
        self.children = [None]*128

class Trie:
    root = TrieNode(False)

    def insert_word(self, word, node=root, index=0):
        #print('Insert word', word, 'char is ', word[index])
        currNode = node.children[ord(word[index])] 
        if currNode == None:
            currNode = TrieNode(False)
            node.children[ord(word[index])] = currNode

        if index == (len(word) - 1): 
            currNode.is_terminal_node = True
            return
        
        self.insert_word(word, currNode, index + 1)

    def search_word(self, word, node=root, index=0):
        if node == None: 
            return False

        currNode = node.children[ord(word[index])]
        #print('Current node is ', word[index])

        if currNode == None: 
            return False

        if (index == len(word) - 1 and currNode.is_terminal_node == True):
            return True

        return self.search_word(word, currNode, index+1)
        


class WordSearch(object):

    def findWords(self, board, words):
        """
        :type board: List[List[str]]
        :type words: List[str]
        :rtype: List[str]
        """
        trie = Trie()
        for i in range(len(words)):
            trie.insert_word(words[i])
            print(trie.search_word(words[i]))

        rows = len(board)
        cols = len(board[0])
        for i in range(n):
            for j in range(m):

        

ws = WordSearch()
words = ["eat","oath"]
ws.findWords(None, words)

