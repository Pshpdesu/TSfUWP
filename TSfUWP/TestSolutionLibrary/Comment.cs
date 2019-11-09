using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSolutionLibrary
{
    public class Comment
    {
        public int Id { get; set; }
        public UserProfile UserProfile { get; set; } = new UserProfile();
        public string CommentBody { get; set; }
    }
}
