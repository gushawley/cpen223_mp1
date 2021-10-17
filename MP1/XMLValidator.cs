// MP1: XML Validator
// Implementation of the XMLValidator class.

// You should implement this class.
// You should add comments, documentation comments, and improve the documentation.

using System;
using System.Collections.Generic;
using System.Text;

namespace XMLValidatorNS
{
    public class XMLValidator
    {
        
        private Queue<XMLTag> tags;

        /// <summary>
        /// Constructor for XMLValidator.
        /// (used when no queue passed)
        /// </summary>
        public XMLValidator()
        {
            this.tags = new Queue<XMLTag>();
        }

        /// <summary>
        /// Constructor for XMLValidator
        /// (used when queue passed)
        /// </summary>
        /// <param name="tags">Queue of type XMLTag to be used by XMLValidator</param>
        public XMLValidator(Queue<XMLTag> tags)
        {
            this.tags = new Queue<XMLTag>(tags.ToArray()); //from MS documentation for Queue<T>.ToArray
            
        }

        /// <summary>
        /// Adds passed XMLTag to the end of the tag queue.
        /// </summary>
        /// <param name="tag">tag to be added to queue</param>
        public void AddTag(XMLTag tag)
        {
            //if no tag passed, throw ArgumentException
            if (tag == null)
            {
                throw new ArgumentException("No tag to add.");
            }

            //enqueue passed tag
            tags.Enqueue(tag);
        }

        /// <summary>
        /// method for getting the queue of tags as a string in the form: "front [ (tags) ] back"
        /// </summary>
        /// <returns>tags in queue as a string with form: "front [ (tags) ] back" </returns>
        public string GetTags() 
        {
            //create new StringBuilder object to hold created string and add "front [" start the string
            StringBuilder tagString = new StringBuilder();
            tagString.Append("front [ ");

            //loop through the queue exactly once
            for (int i = 0; i < tags.Count; i++)
            {
                //dequeue each XMLTag, add it to the StringBuilder, and enqueue
                //by the end of the loop, the queue will be the same
                XMLTag tempTag = tags.Dequeue();
                tagString.Append(tempTag.ToString());
                tags.Enqueue(tempTag);
            }
            tagString.Append(" ] back");
            return tagString.ToString();
        }

        /// <summary>
        /// removes 'XMLTag's in queue of the passed type
        /// if passed string is in the form "element_name", removes all open and close tags
        /// if passed string is in tag form, removes only the instances mathcing the passed tag
        /// throws Argument Exception if string passed is null
        /// </summary>
        /// <param name="element">string of element name or tag form of tags to be removed from the queue</param>
        public void Remove(string element)
        {
            //hold number of elements in queue in a seperate variable to be held constant
            int startCount = tags.Count;
            
            //
            for (int i = 0; i < startCount; i++)
            {
                XMLTag tempTag = tags.Dequeue();
                if (tempTag.GetElement() != element && tempTag.ToString().Replace(" ","") != element)
                {
                    tags.Enqueue(tempTag);
                }
                
            }
        }

        public void Validate()
        {
            MyStack validateStack = new MyStack();
            int tagsCount = tags.Count;
            StringBuilder indentation = new StringBuilder();

            for (int i = 0; i < tagsCount; i++)
            {
                XMLTag tempTag = tags.Dequeue();
                if (tempTag.IsSelfClosing())
                {
                    Console.WriteLine($"{indentation.ToString()}{tempTag.ToString().Replace(" ", "")}");
                }
                else if (tempTag.GetIsOpenTag() && !tempTag.IsSelfClosing())
                {
                    Console.WriteLine($"{indentation.ToString()}{tempTag.ToString().Replace(" ", "")}");
                    validateStack.Push(tempTag);
                    indentation.Append("   ");
                }
                else if (!tempTag.GetIsOpenTag() && !tempTag.IsSelfClosing())
                {
                    if (tempTag.IsEqual(validateStack.Peek()))
                    {
                        Console.WriteLine($"{indentation.ToString()}{tempTag.ToString().Replace(" ", "")}");
                        validateStack.Pop();
                        indentation.Remove(0, 3);
                    }
                    else
                    {
                        Console.WriteLine($"Unexpected tag error: {tempTag.ToString().Replace(" ", "")}");
                    }
                }
            }
            while (!validateStack.IsEmpty())
            {
                Console.WriteLine($"Unclosed tag error: {validateStack.Pop().ToString().Replace(" ", "")}");
            }

        }

    }
}
