using System;
using SQLite;

namespace DifferenzXamarinDemo.Helpers
{
    /// <summary>
    /// ISQLite - Contains declarations for SQLite Operations
    /// </summary>
	public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
