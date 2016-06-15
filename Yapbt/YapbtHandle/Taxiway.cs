using Org.Strausshome.Yapbt.DataConnection;

namespace Org.Strausshome.Yapbt.YapbtHandle
{
    public class Taxiway
    {
        public TempPoint FromPoint { get; set; }
        public TempPoint ToPoint { get; set; }
        public string Type { get; set; }
    }
}
