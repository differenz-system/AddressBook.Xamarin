using System;
using SQLite;

namespace DifferenzXamarinDemo
{
    /// <summary>
    /// ISQLite - Contains declarations for SQLite Operations
    /// </summary>
	public interface ISQLite {
		SQLiteConnection GetConnection();
	}
}

