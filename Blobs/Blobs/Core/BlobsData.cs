using System.Collections.Generic;
using Blobs.Interfaces;

namespace Blobs.Core
{
    public class BlobsData : IBlobsData
    {
        private readonly ICollection<IBlob> blobs = new List<IBlob>();
       
        public void AddBlob(IBlob blob)
        {
            this.blobs.Add(blob);
        }

        public IEnumerable<IBlob> Blobs {get { return this.blobs; } }
    }
}