using Org.Strausshome.Yapbt.DataConnection;

namespace Org.Strausshome.Yapbt.YapbtEditor.Objects
{
    public class Fields
    {
        /// <summary>
        /// Gets or sets the current configuration of the editor.
        /// </summary>
        public YapbtHandle.Configuration Config { get; set; }

        /// <summary>
        /// Gets or sets the current airport.
        /// </summary>
        public Airport CurrentAirport { get; set; }
    }
}
