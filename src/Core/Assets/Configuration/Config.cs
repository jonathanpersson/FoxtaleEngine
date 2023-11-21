using System;
using System.Xml.Serialization;

namespace Foxtale.Core.Assets.Configuration;

public class Config
{
    public readonly int Version = 1;
    public bool AutoRebuild;
    public bool LoadRaw;
    public string[] Bundles;
    public DateTime LastBuild;

    public static Config GetDefault()
    {
        return new(){
            AutoRebuild = true,
            LoadRaw = false,
            Bundles = [],
            LastBuild = DateTime.Today,
        };
    }
}
