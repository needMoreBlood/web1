using System;
using System.Collections.Generic;


namespace TatooParlor
{
    
    /// <summary>
    /// запись в салон
    /// </summary>
    public class Registration
    {
        /// <summary>
        /// контактные данные клиента (имя, возраст, контакты, пол)
        /// </summary>
       
        public string Contacts { get; set; }

        public string Gender { get; set; }

        public DateTime DateToVisit { get; set; }

        public string TatooStyles { get; set; }

        public string BodyPart { get; set; }

        public string Master { get; set; }

        public override string ToString()
        {
            return $" Телефон: {Contacts}, Часть тела: {BodyPart},"+
             $"Cтиль тату: {TatooStyles}, Мастер: {Master}, Дата: {DateToVisit}";
        }

    }    
}
