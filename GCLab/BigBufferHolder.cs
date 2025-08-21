using System.Buffers;

namespace GCLab;

static class BigBufferHolder
{
    private static readonly ArrayPool<byte> Pool = ArrayPool<byte>.Shared;

    public static byte[] Run()
    {

        var big = Pool.Rent(200_000);
        try
        {
            big[0] = 42; 

            var small = new byte[1024];
            Array.Copy(big, small, small.Length);

            GlobalCache.Add(small);
            return small;
        }
        finally
        {
            Pool.Return(big, clearArray: true);
        }
    }
}
