using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStructeres
{
    public class DoublyLinkedList
    {
        private class LinkNode
        {
            public int Value { get; set; }
            public LinkNode NextNode { get; set; }
            public LinkNode PreviousNode { get; set; }
            public LinkNode(int value)
            {
                this.Value = value;
            }
        }
            private LinkNode head;
            private LinkNode tail;
            public int Count { get; private set; }//count of the list
            public void AddFirst(int value)
            {
                LinkNode newHead = new LinkNode(value);
                if (this.Count == 0) //Empty list -> аdd the new element as head and tail at the same time
                {
                    this.head = newHead;
                    this.tail = newHead;
                }
                else //Non-empty list -> add the new element as a new head and redirect the old head as the second element, just after the new head.
                {
                    newHead.NextNode = this.head;
                    this.head.PreviousNode = newHead;
                    this.head = newHead;
                }
                this.Count += 1;
            }
            public void AddLast(int value)
            {
                LinkNode newTail = new LinkNode(value);
                if (this.Count == 0) 
                {
                    this.head = newTail;
                    this.tail = newTail;
                }
                else
                {
                    newTail.PreviousNode = this.tail;
                    this.tail.NextNode = newTail;
                    this.tail = newTail;
                }
                this.Count += 1;
            }
            public int RemoveFirst()
            {
                if (this.Count ==0) throw new InvalidOperationException("The list is empty"); 
                var firstElement = this.head.Value;
                this.head = this.head.NextNode;
                if (this.head != null)
                {
                    this.head.PreviousNode = null;
                }
                else //if this.head is == null
                {
                    this.tail = null;
                }
                this.Count--;
                return firstElement;
            }
            public int RemoveLast()
            {
                if (this.Count == 0) throw new InvalidOperationException("The list is empty");
                var lastElement = this.tail.Value;
                this.tail = this.tail.PreviousNode;
                if (this.head != null)
                {
                    this.tail.NextNode= null;
                }
                else //if this.tail is == null
                {
                    this.head = null;
                }
                this.Count--;
                return lastElement;
            }
            public void ForEach(Action<int> action)
            {
                var currNode = this.head;
                while (currNode!=null)
                {
                    action(currNode.Value);
                    currNode = currNode.NextNode;
                }
            }
            public int[] ToArray()
            {
                var array = new int[this.Count];
                int cnt = 0;
                var currNode = this.head;
                while (currNode!=null)
                {
                    array[cnt] = currNode.Value;
                    currNode = currNode.NextNode;
                    cnt += 1;
                }
                return array;
            }
        }
    }

