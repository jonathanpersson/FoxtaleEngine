using System;
using System.Xml.Serialization;

namespace Foxtale.Core.Assets;

[Serializable]
public class Asset
{
    public Guid Id { get; set; }
    public object Data { get; set; }
}
