namespace GCLab;

class LeakySubscriber
{

    private static readonly List<WeakReference<LeakySubscriber>> _registry = new();

    private Publisher? _publisher;

    public LeakySubscriber(Publisher publisher)
    {
        _publisher = publisher;
        _publisher.OnSomething += Handle;
        _registry.Add(new WeakReference<LeakySubscriber>(this));
    }

    private void Handle() { /* noop */ }

    ~LeakySubscriber()
    {

        try
        {
            if (_publisher is not null)
                _publisher.OnSomething -= Handle;
        }
        catch { /* ignore */ }
        finally
        {
            _publisher = null;
        }
    }
}
