using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
    class Playlist : DbContext
    {
        private int Id;
        private string Name;
    }
}
