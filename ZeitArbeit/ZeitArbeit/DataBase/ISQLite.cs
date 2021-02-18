using System;
using System.Collections.Generic;
using System.Text;

namespace ZeitArbeit.DataBase
{
    using SQLite;
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
