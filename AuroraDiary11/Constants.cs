using System;
using System.IO;

namespace AuroraDiary
{
    public static class Constants
    {
        public const string EMAIL_KEY = "email_key";
        public const string PASSWORD_KEY = "password_key";
        public const string REMEMBER_ME_KEY = "remember_me_key";

        public const string DatabaseFilename = "AuroraDiarySQLite.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            SQLite.SQLiteOpenFlags.ReadWrite |
            SQLite.SQLiteOpenFlags.Create |
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }
    }
}
