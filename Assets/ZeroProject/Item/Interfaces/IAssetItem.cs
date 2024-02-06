using UnityEngine;
using ZeroProject.Stats.Realisation;

namespace ZeroProject.Item.Interfaces
{
    public interface IAssetItem
    {
        ItemID ID { get; set; }
        Sprite Icon { get; set; }
        string Name { get; set; }
    }
}