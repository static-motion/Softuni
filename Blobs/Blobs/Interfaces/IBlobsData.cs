using System.Collections.Generic;

namespace Blobs.Interfaces
{
    public interface IBlobsData
    {
        IEnumerable<IBlob> Blobs { get; }

        void AddBlob(IBlob blob);
    }
}