using System;
using System.Linq;
using System.Collections.Generic;

namespace Foxtale.Core.Assets;

[Serializable]
public class Bundle
{
    private List<Asset> _assets;
    private Dictionary<string, Guid> _assetIds;
    public Guid Id { get; set; }

    public Asset this[Guid id]
    {
        get
        {
            Asset a =
                (Asset)(from asset in _assets
                where asset.Id == id
                select asset);
            return a;
        }
    }

    public Asset this[string name]
    {
        get => this[_assetIds[name]];
    }

    public Bundle()
    {
        Id = new();
        _assets = [];
        _assetIds = [];
    }

    public Bundle(Guid id, List<Asset> assets, Dictionary<string, Guid> ids)
    {
        Id = id;
        _assets = assets;
        _assetIds = ids;
    }
}
