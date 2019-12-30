using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask05.ExceptionClasses
{

    /// <summary>
    /// The class which describes exception for TreeNode
    /// </summary>
    public class TreeNodeException : Exception
    {
        public TreeNodeException()
        {
        }

        public TreeNodeException(string message) : base(message)
        {
        }

    }
}
