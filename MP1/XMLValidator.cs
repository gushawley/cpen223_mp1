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
            
        }

        public string GetTags() 
        {
            return null; // return a dummy value for now
        }

        public void Remove(string element)
        {
 
        }

        public void Validate()
        {
 
        }

    }
}
