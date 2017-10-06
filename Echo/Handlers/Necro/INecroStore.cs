using Echo.Handlers.Necro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Echo.Handlers.Necros
{
    public interface INecroStore<TNecro> : IDisposable where TNecro : NecroModel
    {
        Task CreateNecroAsync(TNecro Necro, CancellationToken CancellationToken);
        Task<NecroModel> NecroInfoAsync(TNecro Necro, CancellationToken CancellationToken);
        Task<NecroModel> DeleteNecroAsync(TNecro Necro, CancellationToken CancellationToken);

        //http://www.elemarjr.com/en/2017/05/writing-an-asp-net-core-identity-storage-provider-from-scratch-with-ravendb/
    }
}