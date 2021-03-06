﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spielzeugverleih.Models
{
    public class Spielzeug
    {
        public virtual int SpielzeugID { get; set; }
        public virtual int SpielzeugTypID { get; set; }
        public virtual string Name { get; set; }
        public virtual string Bild { get; set; }
        public virtual string Beschreibung { get; set; }
        public virtual float Price { get; set; }
        public virtual bool Vorhanden { get; set; }
        public virtual SpielzeugTyp SpielzeugTyp { get; set; }
        public virtual List<Ausgeliehen> AusgeliehenID { get; set; }
    }
}