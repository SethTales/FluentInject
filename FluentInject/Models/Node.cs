using System.Collections.Generic;

namespace FluentInject.Models
{
    internal class Node<T>
    {
        internal T Data { get; set; }
        internal object ActivatedObject { get; set; }
        internal Node<T> ParentNode { get; set; }
        internal List<Node<T>> ChildNodes { get; } = new List<Node<T>>();
        internal List<object> ActivatedDependencies { get; } = new List<object>();
    }
}
