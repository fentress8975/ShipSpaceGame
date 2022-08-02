namespace ShipBase
{
    public class Faction
    {
        public Faction(Side side)
        {
            m_Side = side;
        }

        public Side m_Side { get; private set; }

        public void ChangeFaction(Side side)
        {
            m_Side = side;
        }

        public enum Side
        {
            BLUFOR,
            REDFOR
        }
    }
}