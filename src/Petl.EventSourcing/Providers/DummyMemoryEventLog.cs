namespace Petl.EventSourcing.Providers;

public class DummyMemoryEventLog<TView, TEvent> : IEventLog<TView, TEvent>
    where TView : class, new()
    where TEvent : class
{
    private readonly TView _view = new();
    private int _version = 0;
    
    public Task Hydrate()
    {
        return Task.CompletedTask;
    }

    public void Submit(TEvent entry)
    {
        dynamic s = _view;
        dynamic e = entry;
        s.Apply(e);
        _version++;
    }

    public void Submit(IEnumerable<TEvent> entries)
    {
        foreach (var ev in entries)
        {
            Submit(ev);
        }
    }

    public Task Snapshot(bool truncate)
    {
        /* no op */
        return Task.CompletedTask;
    }

    public Task WaitForConfirmation()
    {
        return Task.CompletedTask;
    }

    public TView ConfirmedView => _view;
    public int ConfirmedVersion => _version;
}