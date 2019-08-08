namespace LC_FB_Easy
{
    /*
        A strobogrammatic number is a number that looks the same when rotated 180 degrees (looked at upside down).
        Write a function to determine if a number is strobogrammatic. The number is represented as a string.
        
        Example 1:
        Input:  "69"
        Output: true

        Example 2:
        Input:  "88"
        Output: true

        Example 3:
        Input:  "962"
        Output: false        
        */    
    class StrobogrammaticNumbers
    {
        public bool IsStrobogrammatic(string num)
        {
            if (num != null && num.Length == 1){
                if (num == "8" || num == "0" || num == "1") return true;
                return false;
            }
            
            int i = 0;
            int j = num.Length - 1;
            while (i <= j)
            {
                // The only Strobogrammatic #s are {6,9} {8,8}, {1,1} and {0,0}.
                switch(num[i])
                {
                    case '6':
                        if (num[j] != '9') return false;
                        break;
                    case '9':
                        if (num[j] != '6') return false;
                        break;
                    case '8':
                        if (num[j] != '8') return false;
                        break;
                    case '0':
                        if (num[j] != '0') return false;
                        break;
                    case '1':
                        if (num[j] != '1') return false;
                        break;                    
                    default:
                        return false;
                }
                
                i++; j--;
            }
            
            return true;            
        }
    }
}