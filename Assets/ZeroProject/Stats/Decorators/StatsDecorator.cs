using ZeroProject.Stats.Interfaces;

namespace ZeroProject.Stats.Realisation
{
    public abstract class StatsDecorator : IStatsProvider
    {
        private readonly IStatsProvider _wrappedEntity;

        public StatsDecorator(IStatsProvider wrappedEntity)
        {
            _wrappedEntity = wrappedEntity;
        }
        
        public PlayerStats GetStats()
        {
            return GetInternalStats();
        }

        protected abstract PlayerStats GetInternalStats();
    }
}