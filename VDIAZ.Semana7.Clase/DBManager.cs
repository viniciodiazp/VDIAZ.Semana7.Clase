using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace VDIAZ.Semana7.Clase
{
    public interface DBManager
    {
        SQLiteAsyncConnection GetConnection();
    }
}
