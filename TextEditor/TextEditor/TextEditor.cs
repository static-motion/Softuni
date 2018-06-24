using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace TextEditor
{
    class TextEditor : ITextEditor
    {
        private Trie<BigList<char>> usersString;
        private Trie<Stack<string>> userStack;

        public TextEditor()
        {
            this.usersString = new Trie<BigList<char>>();
            this.userStack = new Trie<Stack<string>>();
        }
        public void Login(string username)
        {
            this.usersString.Insert(username, new BigList<char>());
            this.userStack.Insert(username, new Stack<string>());
        }

        public void Logout(string username)
        {
            this.usersString.Delete(username);
            this.userStack.Delete(username);
        }

        public void Prepend(string username, string str)
        {
            if (!this.usersString.Contains(username))
            {
                return;
            }

            Backup(username);
            this.usersString.GetValue(username).AddRangeToFront(str);
        }

        public void Insert(string username, int index, string str)
        {
            Backup(username);
            this.usersString.GetValue(username).InsertRange(index, str);
        }

        public void Substring(string username, int startIndex, int length)
        {
            var substring = this.usersString.GetValue(username).GetRange(startIndex, length);
            Backup(username);
            this.usersString.GetValue(username).Clear();
            this.usersString.GetValue(username).AddRange(substring);
        }

        public void Delete(string username, int startIndex, int length)
        {
            Backup(username);
            this.usersString.GetValue(username).RemoveRange(startIndex, length);
        }

        private void Backup(string username)
        {
            this.userStack.GetValue(username).Push(string.Join("", this.usersString.GetValue(username)));
        }

        public void Clear(string username)
        {
            Backup(username);
            this.usersString.GetValue(username).Clear();
        }

        public int Length(string username)
        {
            return this.usersString.GetValue(username).Count;
        }

        public string Print(string username)
        {
            if (!usersString.Contains(username))
            {
                return "";
            }
            return string.Join("", usersString.GetValue(username));
        }

        public void Undo(string username)
        {
            this.usersString.GetValue(username).Clear();
            this.usersString.GetValue(username).AddRangeToFront(this.userStack.GetValue(username).Pop());
        }

        public IEnumerable<string> Users(string prefix = "")
        {
            return this.usersString.GetByPrefix(prefix);
        }
    }
}
