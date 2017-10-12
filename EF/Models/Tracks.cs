using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
    internal class Track : DbContext
    {
        private int Id;
        private String Name;
        private int Length;
        private DateTime Release;
        private long NumberOfPlay;
        private string TrackLocation;
    }
}
