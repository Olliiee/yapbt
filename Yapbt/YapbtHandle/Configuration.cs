using System;
using System.Linq;
using Org.Strausshome.Yapbt.Codes;
using Org.Strausshome.Yapbt.DataConnection;

namespace Org.Strausshome.Yapbt.YapbtHandle
{
    public class Configuration
    {
        /// <summary>
        /// Check the database connection.
        /// </summary>
        /// <returns>True able to open the connection
        /// false unable to open the connection.</returns>
        public bool CheckDbConnection()
        {
            var db = new YapbtDbEntities();

            try
            {
                db.Database.Connection.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Return the needed configuration value.
        /// </summary>
        /// <param name="needle">The configuration part.</param>
        /// <returns>The value of the needle.</returns>
        public string ReadConfig(string needle)
        {
            using (var db = new YapbtDbEntities())
            {
                try
                {
                    return db.Configuration.Where(c => c.Setting == needle).Select(d => d.Value).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// Set the config value
        /// </summary>
        /// <param name="needle">The configuration part.</param>
        /// <param name="value">The new value.</param>
        /// <returns>Return an error code.</returns>
        public ReturnCodes.Codes SetConfig(string needle, string value)
        {
            using (var db = new YapbtDbEntities())
            {
                try
                {
                    var item = db.Configuration.Where(c => c.Setting == needle).FirstOrDefault();
                    item.Value = value;
                    db.SaveChanges();

                    return ReturnCodes.Codes.Ok;

                }
                catch (Exception ex)
                {
                    return ReturnCodes.Codes.Error;
                }
            }
        }
    }
}
