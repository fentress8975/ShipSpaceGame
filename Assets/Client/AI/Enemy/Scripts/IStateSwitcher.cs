using AI;


namespace AI
{
    public interface IStateSwitcher
    {
        public void StateSwitcher<T>() where T : EnemyBaseState;
    }
}
