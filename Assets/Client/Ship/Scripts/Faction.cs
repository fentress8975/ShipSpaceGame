namespace ShipBase
{
    public class Faction
    {
        public Faction(Side side)
        {
            m_Side = side;
        }

        public Side m_Side { get; private set; }

        public enum Side
        {
            BLUFOR,
            REDFOR
        }
    }
}