namespace LC_FB_Easy
{
    /*
        Given two strings S and T, return if they are equal when both are typed into empty text editors. # means a backspace character.
        Follow up: Can you solve it in O(N) time and O(1) space?
            Example 1:
            Input: S = "ab#c", T = "ad#c"
            Output: true
            Explanation: Both S and T become "ac".

            Example 2:
            Input: S = "ab##", T = "c#d#"
            Output: true
            Explanation: Both S and T become "".

            Example 3:
            Input: S = "a##c", T = "#a#c"
            Output: true
            Explanation: Both S and T become "c".

            Example 4:
            Input: S = "a#c", T = "b"
            Output: false
            Explanation: S becomes "c" while T becomes "b".        
     */    
    class BackspaceStringCompare
    {
        // The below logic uses O(M + N) time and O(1) space.
        // You can solve the problem in O(M + N) space by using a stack based approach
        public bool BackspaceCompare(string S, string T)
        {
            int sIndex = S.Length - 1;
            int tIndex = T.Length - 1;
            int sBackspaceCount = 0;
            int tBackspaceCount = 0;

            while(sIndex >=0 || tIndex >= 0)
            {
                // If either of the chars we are processing is a #,
                // or if the backspace count is non zero,
                // we cannot perform the char comparison
                if ((sIndex >= 0 && S[sIndex] == '#') || (tIndex >= 0 && T[tIndex] == '#')) {
                    if (sIndex >= 0 && S[sIndex] == '#') {
                        ++sBackspaceCount;
                        sIndex--;
                    }
                    if (tIndex >= 0 && T[tIndex] == '#') {
                        ++tBackspaceCount;
                        tIndex--;
                    }
                } else if (sBackspaceCount != 0 || tBackspaceCount != 0) {
                    if (sBackspaceCount != 0) {
                        sIndex--;
                        sBackspaceCount--;
                    }
                    if (tBackspaceCount != 0) {
                        tIndex--;
                        tBackspaceCount--;
                    }
                } else if (sIndex < 0 || tIndex < 0 || S[sIndex] != T[tIndex]) {
                    return false;
                } else {
                    // chars are the same
                    sIndex--;
                    tIndex--;
                }
            }

            if (sIndex < 0 && tIndex < 0) return true;
            return false;
        }
    }
}