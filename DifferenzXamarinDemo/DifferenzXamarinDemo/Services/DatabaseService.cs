using System;
using System.Collections.Generic;
using System.IO;
using DifferenzXamarinDemo.Models;
using SQLite;

namespace DifferenzXamarinDemo.Services
{
    /// <summary>
    /// ISQLite - Contains declarations for SQLite Operations
    /// </summary>
	public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }

    public class DatabaseService
    {
        public DatabaseService()
        {
        }

        static SQLiteConnection _instance;
        public static SQLiteConnection Instance
        {
            get
            {
                if (_instance == null)
                {
                    string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TodoSQLite.db3");
                    _instance = new SQLiteConnection(dbPath);
                    _instance.CreateTable<UserData>();
                }
                return _instance;
            }
            set
            {
                _instance = value;
            }
        }

        static object locker = new object();

        /// <summary>
        /// Gets the user address data.
        /// </summary>
        /// <returns>user address data.</returns>
        /// <param name="EmailAddress">Email address.</param>
		public static UserData GetItem(string EmailAddress)
        {
            lock (locker)
            {
                return DatabaseService.Instance.Table<UserData>().FirstOrDefault(x => x.EmailAddress == EmailAddress);
            }
        }

        /// <summary>
        /// Gets all user address data.
        /// </summary>
        /// <returns>all user address data.</returns>
		public static List<UserData> GetAll()
        {
            lock (locker)
            {
                return DatabaseService.Instance.Table<UserData>().ToList();
            }
        }

        /// <summary>
        /// Saves the user address data.
        /// </summary>
        /// <returns>user address data.</returns>
        /// <param name="item">Item.</param>
		public static int SaveItem(UserData item)
        {
            lock (locker)
            {
                if (item.ID != 0)
                {
                    DatabaseService.Instance.Update(item);
                    return item.ID;
                }
                else
                {
                    return DatabaseService.Instance.Insert(item);
                }
            }
        }

        /// <summary>
        /// Deletes the user address data.
        /// </summary>
        /// <returns>user address data.</returns>
        /// <param name="id">Identifier.</param>
		public static int DeleteItem(int id)
        {
            lock (locker)
            {
                return DatabaseService.Instance.Delete<UserData>(id);
            }
        }
    }
}
