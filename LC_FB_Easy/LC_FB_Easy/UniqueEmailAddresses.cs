using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LC_FB_Easy
{
/*
    Every email consists of a local name and a domain name, separated by the @ sign.
    For example, in alice@leetcode.com, alice is the local name, and leetcode.com is the domain name.
    Besides lowercase letters, these emails may contain '.'s or '+'s.
    If you add periods ('.') between some characters in the local name part of an email address, mail sent there will be forwarded to the same address without dots in the local name.  
    For example, "alice.z@leetcode.com" and "alicez@leetcode.com" forward to the same email address.  (Note that this rule does not apply for domain names.)
    If you add a plus ('+') in the local name, everything after the first plus sign will be ignored. 
    This allows certain emails to be filtered, for example m.y+name@email.com will be forwarded to my@email.com.  (Again, this rule does not apply for domain names.)
    It is possible to use both of these rules at the same time.
    Given a list of emails, we send one email to each address i the list.  How many different addresses actually receive mails?

    Exampel 1:
        Input: ["test.email+alex@leetcode.com","test.e.mail+bob.cathy@leetcode.com","testemail+david@lee.tcode.com"]
        Output: 2
        Explanation: "testemail@leetcode.com" and "testemail@lee.tcode.com" actually receive mails
*/
    class UniqueEmailAddresses
    {
        // if @, copy rest of string
        // if +, skip all chars until @
        // if ., skip
        public int NumUniqueEmails(string[] emails)
        {
            HashSet<string> output = new HashSet<string>();

            for (int i = 0; i < emails.Length; i++)
            {
                string emailAddress = emails[i];
                StringBuilder sb = new StringBuilder();
                bool skipUntilAt = false;

                for (int j = 0; j < emailAddress.Length; j++)
                {
                    if (emailAddress[j] == '@')
                    {
                        sb.Append(emailAddress.Substring(j));
                        break;
                    }
                    if (skipUntilAt)
                    {
                        continue;
                    }
                    else if (emailAddress[j] == '+')
                    {
                        skipUntilAt = true;
                    }
                    else if (emailAddress[j] != '.')
                    {
                        sb.Append(emailAddress[j]);
                    }
                }

                output.Add(sb.ToString());
            }

            return output.Count;
        }
    }
}
