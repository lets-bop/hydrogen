def palindrome_helper(s, start, end):
    palindromes = []

    while (start >= 0 and end < len(s) and s[start] == s[end]):
        palindromes.append(s[start:end + 1])
        start -= 1
        end += 1

    return palindromes

s = 'ababa'
palindromes = []
for i in range(len(s)):
    palindromes += palindrome_helper(s, i, i) # odd
    palindromes += palindrome_helper(s, i, i+1) # odd

print(*palindromes, sep=', ')