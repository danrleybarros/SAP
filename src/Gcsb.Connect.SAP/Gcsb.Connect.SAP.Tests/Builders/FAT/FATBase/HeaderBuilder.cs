using Gcsb.Connect.SAP.Domain.FAT.FATBase;
using Gcsb.Connect.SAP.Domain.JSDN.Stores;

namespace Gcsb.Connect.SAP.Tests.Builders.FAT.FATBase
{
    public class HeaderBuilder
    {
        public StoreType Type;

        public static HeaderBuilder New()
        {
            return new HeaderBuilder
            {
                Type = StoreType.TBRA,
            };
        }

        public Header Build()
            => new Header(Type);
    }
}
