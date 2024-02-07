using System;
using UnityEngine;

namespace ZeroProject.Stats.Realisation
{
    public class ItemDataBase : ScriptableObject
    {
        [SerializeField] private DataItem[] _dataItems;
        
    }
    
    
    
    [Serializable]
    public class DataItem
    {
        
    }

    public enum ItemID
    {
        
    }
}