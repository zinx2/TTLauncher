using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TTLauncher.Editor.Models
{
    public class TTSeries
    {
        public TTSeries()
            : this(Guid.NewGuid())
        {
        }
        public TTSeries(Guid id)
        {
            this.Id = id;
        }
        public Guid Id { get; private set; }
        public string Name { get; set; }
        public string ThumbnailPath { get; set; }
        public bool IsSecret { get; set; }
    }
}
