using System;
using System.Collections.Generic;

namespace TatooParlor
{
    /// <summary>
    /// салон
    /// </summary>
    public class TatooSalon
    {
        public List<Registration> Journal { get; set; }

        public List<Comments> CommetsPage { get; set; }

        public string VisitorName { get; set; }

        public string Age { get; set; }

        public byte[] Photo { get; set; }

    }
    
}
