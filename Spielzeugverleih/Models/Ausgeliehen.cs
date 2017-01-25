using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spielzeugverleih.Models
{
    public class Ausgeliehen
    {
        public virtual int AusgeliehenID { get; set; }
        public virtual int SpielzeugID { get; set; }
        public virtual DateTime DatumVon { get; set; }
        public virtual DateTime DatumBis { get; set; }
        public virtual float Price { get; set; }
        public virtual int MieterID { get; set; }
        public virtual Spielzeug Spielzeug { get; set; }
    }
}