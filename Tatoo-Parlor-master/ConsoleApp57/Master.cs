using System;
using System.Collections.Generic;

namespace TatooParlor
{ 
/// <summary>
/// описание мастнров
/// </summary>
    public class Master
    {        
        public string Name { get; set; }
        
        public bool[] Photo { get; set; }      

        /// <summary>
        /// описание: где учился, сколько занимается и т.п
        /// </summary>
        public string Discription { get; set; }

        /// <summary>
        /// стиль, с которым работает мастер
        /// </summary>
        public List<string> MasterStyles { get; set; } 

       // public List<Tatoo> Examples { get; set; }

        /// <summary>
        /// график работы и свободные дни
        /// </summary>
        //public Dictionary<DateTime, Registration> TimeTable { get; set; }

    }
}
