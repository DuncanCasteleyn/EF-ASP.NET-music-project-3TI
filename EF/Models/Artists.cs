using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
    class Artists : DbContext
    {
        private int Id;
        private string name;
        private String RealName;
        private Gender Gender;
        private String BirthCountry;
    }

    public enum Gender
    {
        Female,
        Male
    }
}
