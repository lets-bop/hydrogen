using System;
using System.Collections.Generic;

namespace LC_FB_Medium
{
/*
Given a list accounts, each element accounts[i] is a list of strings, where the first 
element accounts[i][0] is a name, and the rest of the elements are emails representing emails of the account. 
Now, we would like to merge these accounts. 
Two accounts definitely belong to the same person if there is some email that is common to both accounts. 
Note that even if two accounts have the same name, they may belong to different people as people 
could have the same name. A person can have any number of accounts initially, 
but all of their accounts definitely have the same name.
After merging the accounts, return the accounts in the following format: 
the first element of each account is the name, and the rest of the elements are emails in sorted order. 
The accounts themselves can be returned in any order.

Example 1:
Input: 
accounts = [
    ["John", "johnsmith@mail.com", "john00@mail.com"], 
    ["John", "johnnybravo@mail.com"], 
    ["John", "johnsmith@mail.com", "john_newyork@mail.com"], 
    ["Mary", "mary@mail.com"]]
Output: [
    ["John", 'john00@mail.com', 'john_newyork@mail.com', 'johnsmith@mail.com'], 
    ["John", "johnnybravo@mail.com"], 
    ["Mary", "mary@mail.com"]]
Explanation: 
The first and third John's are the same person as they have the common email "johnsmith@mail.com".
The second John and Mary are different people as none of their email addresses are used by other accounts.
We could return these lists in any order, for example the answer [['Mary', 'mary@mail.com'], ['John', 'johnnybravo@mail.com'], 
['John', 'john00@mail.com', 'john_newyork@mail.com', 'johnsmith@mail.com']] would still be accepted.
*/

    class AccountsMerge
    {
        public IList<IList<string>> Merge(IList<IList<string>> accounts) {
            // This problem reduces to a graph problem where each node of the graph is an 
            // emailId and its neighbors are the emailIds associated to 1 person.
            // Therefore, if there is any common email between 
            // 2 people, then we'll have 1 connected component which can be identified by doing DFS.
            this.graph = new Dictionary<string, HashSet<string>>();
            this.emailToName = new Dictionary<string, string>();
            this.visited = new HashSet<string>();
            this.BuildGraph(accounts);
            IList<IList<string>> result = new List<IList<string>>();
            
            foreach (string email in emailToName.Keys) {
                if (!this.visited.Contains(email)) {
                    List<string> connectedEmails = new List<string>();
                    connectedEmails.Add(this.emailToName[email]);
                    this.Dfs(email, connectedEmails);
                    connectedEmails.Sort();
                    result.Add(connectedEmails);
                }
            }

            return result;
        }

        private void Dfs(string email, List<string> connectedEmails) {
            this.visited.Add(email);
            connectedEmails.Add(email);
            foreach (string neighbor in this.graph[email]) {
                if (!this.visited.Contains(neighbor)) this.Dfs(neighbor, connectedEmails);
            }
        }

        Dictionary<string, HashSet<string>> graph;
        HashSet<string> visited;
        Dictionary<string, string> emailToName;

        private void BuildGraph(IList<IList<string>> accounts) {
            foreach (IList<string> account in accounts) {
                string name = account[0];
                string firstEmail = string.Empty;

                for (int i = 1; i < account.Count; i++) {
                    this.emailToName[account[i]] = name;

                    if (i == 1) {
                        firstEmail = account[i];
                        if (!this.graph.ContainsKey(firstEmail)) this.graph[firstEmail] = new HashSet<string>();
                        continue;
                    }

                    // add an edge from the first email to this email and an edge from this email to the first email.
                    this.graph[firstEmail].Add(account[i]);
                    if (!this.graph.ContainsKey(account[i])) this.graph[account[i]] = new HashSet<string>();
                    this.graph[account[i]].Add(firstEmail);
                }
            }
        }
    }
}