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
        //field(s) here
        private Queue<XMLTag> tags;

        public XMLValidator()
        {
            this.tags = new Queue<XMLTag>();
        }

        public XMLValidator(Queue<XMLTag> tags)
        {
            this.tags = new Queue<XMLTag>(tags.ToArray());
            
        }

        public void AddTag(XMLTag tag)
        {
            if (tag == null)
            {
                throw new ArgumentException("No tag to add.");
            }

            tags.Enqueue(tag);
        }

        public string GetTags() 
        {
            StringBuilder tagString = new StringBuilder();
            tagString.Append("front [ ");
            for (int i = 0; i < tags.Count; i++)
            {
                XMLTag tempTag = tags.Dequeue();
                tagString.Append(tempTag.ToString());
                tags.Enqueue(tempTag);
            }
            tagString.Append(" ] back");
            return tagString.ToString();
        }

        public void Remove(string element)
        {
            int startCount = tags.Count;
            
            for (int i = 0; i < startCount; i++)
            {
                XMLTag tempTag = tags.Dequeue();
                if (tempTag.GetElement() != element && tempTag.ToString() != element)
                {
                    tags.Enqueue(tempTag);
                }
                
            }
        }

        public void Validate()
        {
 
        }

    }
}
