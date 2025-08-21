namespace GCLab;

static class GlobalCache
{
    private static readonly List<WeakReference<byte[]>> _cache = new();

    public static void Add(byte[] data)
        => _cache.Add(new WeakReference<byte[]>(data));

    public static void Cleanup() => _cache.RemoveAll(wr => !wr.TryGetTarget(out _));
    public static void Clear() => _cache.Clear();
}
