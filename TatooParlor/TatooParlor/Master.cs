using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        /// <summary>
        /// график работы и свободные дни
        /// </summary>
        //public Dictionary<DateTime, Registration> TimeTable { get; set; }

    }
}
