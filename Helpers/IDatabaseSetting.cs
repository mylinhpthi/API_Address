using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Address
{
    public interface IDatabaseSetting
    {
        String CollectionName{  get; set; }
        String CollectionString { get; set; }
        String DatabaseName { get; set; }
    }
}
