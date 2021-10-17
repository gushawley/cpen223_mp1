// MP1: XML Validator
// Implementation of a simple stack for XMLTags.

// You should implement this class.
// You should add comments and improve the documentation.

using System;
using System.Collections.Generic; 

// An obvious reminder: 
// You are only allowed to use List<T> to code your
// own implemenation of a stack type, called MyStack

namespace XMLValidatorNS
{
    public class MyStack
    {
        // A List to hold XMLTag objects.
        // Use this to implement the requested stack.
        private List<XMLTag> stackInternal;

        /// <summary>
        /// Create an empty stack.
        /// </summary>
        public MyStack()
        {
            //creates a stack.
            this.stackInternal = new List<XMLTag>();
        }

        /// <summary>
        /// Push a tag onto the top of the stack.
        /// </summary>
        public void Push(XMLTag tag)
        {
            //adds a tag to the stack
            stackInternal.Add(tag);
        }

        /// <summary> 
        /// Removes the tag at the top of the stack.
        /// Should throw an exception if the stack is empty. 
        /// </summary>
        public XMLTag Pop()
        {
            //if stack is empty, throw ArgumentException.
            if (stackInternal == null)
            {
                throw new ArgumentException("Stack is empty.");
            }

            //removes the top most tag on the stack.
            XMLTag temp = stackInternal[stackInternal.Count - 1];
            stackInternal.RemoveAt(stackInternal.Count - 1);
            return temp;
        }


        /// <summary>
        /// Looks at the object at the top of the stack but does not actually remove the object. 
        /// Should throw an exception if the stack is empty.
        /// </summary>
        public XMLTag Peek()
        {
            //if stack is empty, throw ArgumentException.
            if (stackInternal == null)
            {
                throw new ArgumentException("Stack is empty.");
            }

            //returns the tag at the top of the stack without removing it.
            return stackInternal[stackInternal.Count - 1];
        }

        /// <summary>
        /// Tests if the stack is empty.
        /// Returns true if the stack is empty; false otherwise.
        /// </summary>
        public bool IsEmpty()
        {
            //checks if stack is empty.
            if(stackInternal.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
