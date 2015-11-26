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
                    db.TempParking.SqlQuery(sql);

                    sql = "DROP TABLE [TempPoint];";
                    db.TempParking.SqlQuery(sql);

                    sql = "DROP TABLE [TempParking];";
                    db.TempParking.SqlQuery(sql);

                    // Recreate the table.
                    sql = "CREATE TABLE [TempParking] ("
                            + "[id] bigint NOT NULL"
                            + ", [Name] nvarchar(10) NOT NULL"
                            + ", [Index] bigint NOT NULL"
                            + ", [Number]"
                            + " bigint NOT NULL"
                            + ", [Latitude]"
                            + " float NOT NULL"
                            + ", [LONGITUDE]"
                            + " float NOT NULL"
                            + ", CONSTRAINT[sqlite_master_PK_TempParking] PRIMARY KEY([id])"
                            + ");";

                    db.TempParking.SqlQuery(sql);

                    sql = "CREATE TABLE [TempPoint] ("
                            + "[id] bigint NOT NULL"
                            + ", [Index]"
                            + " bigint NOT NULL"
                            + ", [Latitude]"
                            + " float NOT NULL"
                            + ", [Longitude]"
                            + " float NOT NULL"
                            + ", CONSTRAINT[sqlite_master_PK_TempPoint] PRIMARY KEY([id])"
                            + "); ";

                    db.TempParking.SqlQuery(sql);

                    sql = "CREATE TABLE [TempTaxiway] ("
                            + "[id]"
                            + " bigint NOT NULL"
                            + ", [From]"
                            + " bigint NOT NULL"
                            + ", [To]"
                            + " bigint NOT NULL"
                            + ", CONSTRAINT[sqlite_master_PK_TempTaxiway] PRIMARY KEY([id])"
                            + "); ";

                    db.TempParking.SqlQuery(sql);
                }

                return ReturnCodes.Codes.ResetOk;
            }
            catch (System.Exception)
            {
                return ReturnCodes.Codes.ResetError;
            }
        }
    }
}
