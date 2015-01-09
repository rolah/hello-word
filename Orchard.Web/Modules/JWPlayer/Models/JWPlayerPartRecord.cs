using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orchard.ContentManagement.Records;

namespace JWPlayer.Models
{
    public class JWPlayerPartRecord : ContentPartRecord
    {
        public virtual string PlayerSource { get; set; }
        public virtual int Height { get; set; }
        public virtual int Width { get; set; }
        public virtual string MediaFile { get; set; }
        public virtual bool AutoStart { get; set; }
        public virtual bool Repeat { get; set; }
    }
}