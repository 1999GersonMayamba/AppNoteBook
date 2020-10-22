using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCloudEditor.INTERFACE
{
   public interface Isqlite
    {
        SQLiteConnection GetConnectionBD();
    }
}
