namespace Petl.EventSourcing.Providers;

public class DummyMemoryEventLogFactory : IEventLogFactory {
    public IEventLog<TView, TEntry> Create<TView, TEntry>(Type grainType, string viewId) where TView : class, new() where TEntry : class
    {
        return new DummyMemoryEventLog<TView, TEntry>();
    }
}