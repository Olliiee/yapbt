using Org.Strausshome.Yapbt.DataConnection;

namespace Org.Strausshome.Yapbt.YapbtHandle
{
    /// <summary>
    /// This class handles all parking way data.
    /// </summary>
    public class ParkingWay
    {
        public TempPoint FromPoint { get; set; }
        public TempParking ParkingPoint { get; set; }
        public string Type { get; set; }
    }
}
