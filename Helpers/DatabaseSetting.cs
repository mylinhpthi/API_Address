using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Address.Helpers
{
    public class DatabaseSetting: IDatabaseSetting
    {
        String CollectionName { get; set; }
        string IDatabaseSetting.CollectionName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        String CollectionString { get; set; }
        string IDatabaseSetting.CollectionString { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        String DatabaseName { get; set; }
        string IDatabaseSetting.DatabaseName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
