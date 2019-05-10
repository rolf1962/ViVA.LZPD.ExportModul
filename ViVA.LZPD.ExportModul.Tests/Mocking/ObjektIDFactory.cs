namespace ViVA.LZPD.ExportModul.Tests.Mocking
{
    internal static class ObjektIDFactory
    {
        internal static int GetNextValue()
        {
            return ++CurrentValue;
        }

        internal static int CurrentValue { get; private set; } = 0;
    }
}
