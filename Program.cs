using System;

namespace SinglyLinkedList
{
    class ListNode<T> {
        public T data {get; set;}
        public ListNode<T> next {get; set;}
        public ListNode(T data){
            this.data = data;
            this.next = null;
        }
    }
    class SinglyLinkedList<T> {
        //create a new node  which is null at first
        public ListNode<T> head {get; set;} 

        public void AddFirst(T data){
            // create a new node and add the data to it 
            ListNode<T> newNode = new ListNode<T>(data);
            
            // make the head as the next node of your new node.
            newNode.next = head;
            // make the new node the head because you are adding first
            // now head is the new node that has the data pointing to a null node as the next.
            head = newNode;
        }
        public void AddLast(T data){
            // create a new node for your current data.
            ListNode<T> newNode = new ListNode<T>(data);

            //if the node is empty the head becomes the new node
            if(head == null){
                head = newNode;
            }else{
                // get the current node ie the first node. 
                ListNode<T> current = head; 
                
                // move the current head until we get to the last node
                while(current.next != null){
                     // the current node becomes the next node of the current one.
                     current = current.next;
                }
                // We have the last current node. now we make the next  node of the current node to be our newly created node
                current.next = newNode;
            }

        }
        public void RemoveFirst(){
            // make the next node to be the current head
            if(head !=null){
                head = head.next;
            }
        }
        public void RemoveLast(){
            if(head == null){
                return;
            }
            if(head.next == null){
                head=null;
                return;
            }
            ListNode<T> current = head;
            
            //traverse until the second last node that is not null
           while(current.next.next != null){ 
            current = current.next;
           }
            // once you get to the second last node make the next node null
            current.next = null;
        }

        public void PrintAll(){
            // get the current node ie. the head
            ListNode<T> current = head;
            while(current != null){
                Console.WriteLine(current.data);
                current = current.next;
            }
        }
        public void ReverseList(){
            ListNode<T> next = null;
            ListNode<T> current = head;
            ListNode<T> previous = null;

            while(current != null){
                next = current.next; // get the next node
                current.next = previous; // make the next node of the current node to be the previous one
                previous = current; // make the previous to be the current. 
                current = next;  // make the current to be the next. 
            }
            head = previous;
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            SinglyLinkedList<int>list = new SinglyLinkedList<int>();
            list.AddFirst(1);
            list.AddLast(5);
            list.AddFirst(2);
            list.AddFirst(3);
            list.AddLast(9);
            list.RemoveLast();
            
            list.PrintAll();
            Console.WriteLine("**********************");
            Console.WriteLine("*   Reversed List    *");
            Console.WriteLine("**********************");
            list.ReverseList();
            list.PrintAll();
        }
    }
}
