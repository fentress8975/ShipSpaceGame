namespace ShipSystem
{
    public interface IShipSystemSO<T> where T : class
    {
        public void Initialization(T moduleSO);
        public T GetModuleSO();
    }
}
