using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace NexmoDotnetCodeSnippets.Models
{
    public class RedactModel
    {
        public enum RedactProduct
        {
            sms,
            voice,            
            numberInsight,
            verify,            
            verifySdk,
            messages

        }
        public enum RedactType
        {
            na,
            inbound,
            outbound
        }
    }
    
}
