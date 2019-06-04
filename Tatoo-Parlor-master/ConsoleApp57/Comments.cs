using System;
using System.Collections.Generic;

namespace TatooParlor
{
    public class Comments
    {
        public string CustumersName { get; set; }

        public string MastersName { get; set; }

        public string Comment { get; set; }

        public DateTime VisitDate { get; set; }

        public override string ToString()
        {
            return $"Имя: {CustumersName}, Имя Мастера: {MastersName}, Отзыв: {Comment}, Дата: {VisitDate}";
        }
    }
}
