using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spielzeugverleih.Models
{
    public class SpielzeugTyp
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
        public virtual List<Spielzeug> Spielzeugs { get; set; }
    }
}