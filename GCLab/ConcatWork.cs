using System.Text;

namespace GCLab;

static class ConcatWork
{
    public static string Bad()
    {
        var sb = new StringBuilder(200_000);
        for (int i = 0; i < 50_000; i++)
            sb.Append(i);
        return sb.ToString();
    }
}
