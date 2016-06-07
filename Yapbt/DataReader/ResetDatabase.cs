using Org.Strausshome.Yapbt.Codes;
using Org.Strausshome.Yapbt.DataConnection;

namespace Org.Strausshome.Yapbt.DataReader
{
    /// <summary>
    /// This class resets the db tables.
    /// </summary>
    public class ResetDatabase
    {
        /// <summary>
        /// Reset the temp tables.
        /// </summary>
        /// <returns></returns>
        public ReturnCodes.Codes ResetTempDatabase()
        {
            try
            {
                using (var db = new YapbtDbEntities())
                {
                    // Drop the table.
                    string sql = "DROP TABLE [TempParking];";
                    db.Database.ExecuteSqlCommand(sql);

                    sql = "DROP TABLE [TempPoint];";
                    db.Database.ExecuteSqlCommand(sql);

                    sql = "DROP TABLE [TempTaxiway];";
                    db.Database.ExecuteSqlCommand(sql);

                    // Recreate the table.
                    sql = "CREATE TABLE [TempParking] ("
                            + "[id] INTEGER DEFAULT '1' NOT NULL PRIMARY KEY AUTOINCREMENT,"
                            + "[Name] VARCHAR(10)  NOT NULL,"
                            + "[Index] INTEGER  NOT NULL,"
                            + "[Number] INTEGER  NOT NULL,"
                            + "[Latitude] REAL  NOT NULL,"
                            + "[Longitude] REAL  NOT NULL"
                            + ");";

                    db.Database.ExecuteSqlCommand(sql);

                    sql = "CREATE TABLE [TempPoint] ("
                            + "[id] INTEGER DEFAULT '1' NOT NULL PRIMARY KEY AUTOINCREMENT,"
                            + "[Index] INTEGER  NOT NULL,"
                            + "[Latitude] REAL  NOT NULL,"
                            + "[Longitude] REAL  NOT NULL"
                            + "); ";

                    db.Database.ExecuteSqlCommand(sql);

                    sql = "CREATE TABLE [TempTaxiway] ("
                            + "[id] INTEGER DEFAULT '1' NOT NULL PRIMARY KEY AUTOINCREMENT,"
                            + "[FromPoint] INTEGER  NOT NULL,"
                            + "[ToPoint] INTEGER  NOT NULL"
                            + "); ";

                    db.Database.ExecuteSqlCommand(sql);
                }

                return ReturnCodes.Codes.ResetOk;
            }
            catch (System.Exception)
            {
                throw;
                return ReturnCodes.Codes.ResetError;
            }
        }
    }
}
