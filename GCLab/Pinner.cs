using System.Runtime.InteropServices;

namespace GCLab;

class Pinner
{
    private GCHandle? _handle;

    public byte[] PinLongTime()
    {
        var data = new byte[256];
        _handle = GCHandle.Alloc(data, GCHandleType.Pinned);

   
        _handle.Value.Free();
        _handle = null;

        return data;
    }

    ~Pinner()
    {
        if (_handle.HasValue && _handle.Value.IsAllocated)
            _handle.Value.Free();
    }
}
