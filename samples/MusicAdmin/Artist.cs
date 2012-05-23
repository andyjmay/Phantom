using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using Phantom;

namespace MusicAdmin {
  [Export(typeof(ModelBase))]
  public class Artist {
    public string Name { get; set; }

  }
}
