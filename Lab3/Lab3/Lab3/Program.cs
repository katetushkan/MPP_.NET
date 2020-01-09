using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<string> tree = new Tree<string>();
           
           
            Console.WriteLine("Enter elements quantity: ");
            int param = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < param; i++)
            {
                Console.WriteLine("Enter element: ");
                var el = Console.ReadLine();

                tree.Add(el);

            }
            foreach (string el in tree)
            {
                Console.Write($"{el}");
            }
            int choice = 1;
            while (choice != 0)
            {
                
                Console.WriteLine("Enter 0 - to exit or 1 - to continue");

                int choice1 = Convert.ToInt32(Console.ReadLine());
                switch (choice1)
                {
                    case 0:
                        choice = 0;
                        break;

                    case 1:
                        Console.WriteLine("Enter element to find: ");
                        var param1 = Console.ReadLine();
                        tree.Search(param1);
                        break;


                }
                
            }
           


            Console.Read();
        }

        class Node<TNode> : IEnumerable<TNode>, IComparable<TNode>
        where TNode : IComparable
        {
            public Node(TNode value)
            {
                Value = value;
            }

            public TNode Value { get; private set; }
            public Node<TNode> Left { get; set; }
            public Node<TNode> Right { get; set; }
            
            public int CompareTo(TNode another)
            {
                return Value.CompareTo(another);
            }

            
            private IEnumerator<TNode> Output(Node<TNode> node)
            {
                

                if ( node.Left != null)
                {
                    foreach (TNode child in node.Left)
                    {
                        yield return child;
                    }
                }
                yield return node.Value;

                if ( node.Right != null)
                {
                    foreach (TNode child in node.Right)
                    {
                        yield return child;
                    }
                }
            }
            public IEnumerator<TNode> GetEnumerator()
            {
                return Output(this);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return Output(this);
            }
        }
        public class Tree<T> : IEnumerable<T>
        where T : IComparable
        {
            private Node<T> head;

            private Node<T> Head { get => head; set => head = value; }

            public void Add(T value)
            {
                if (Head == null)
                {
                    Head = new Node<T>(value);
                }
                else
                {
                    AddRecursively(Head, value);
                }
               
            }

            private void AddRecursively(Node<T> node, T value)
            {
                if (value.CompareTo(node.Value) < 0)
                {
                    if (node.Left == null)
                    {
                        node.Left = new Node<T>(value);
                    }
                    else
                    {
                        AddRecursively(node.Left, value);
                    }
                }
                else
                {
                    if (node.Right == null)
                    {
                        node.Right = new Node<T>(value);
                    }
                    else
                    {
                        AddRecursively(node.Right, value);
                    }
                }
            }

            public void Search(T value)
            {
                if (Head == null)
                {
                    Console.WriteLine("Tree does not exist!");
                }
                else
                {
                    SearchRecursively(Head, value);
                }
            }

            private void SearchRecursively(Node<T> node, T value)
            {
                try
                {
                    if (value.CompareTo(node.Value) == 0)
                    {
                        Console.WriteLine("Here it is!");
                    }
                    else
                    {
                        if (node.Value.Equals(value))
                        {
                            SearchRecursively(node.Left, value);
                        }
                        else
                        {
                            SearchRecursively(node.Right, value);
                        }


                    }
                }catch(NullReferenceException e){
                    Console.WriteLine("There is no Such elem");

                }
                
                

                
            }

            public IEnumerator<T> GetEnumerator()
            {
                return Head.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return Head.GetEnumerator();
            }
        }



    }
}
