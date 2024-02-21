using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRoot : MonoBehaviour
{
    public Transform PoolContainer => poolContainer;
    public Transform Container => container;
    
    [SerializeField] private Transform poolContainer;
    [SerializeField] private Transform container;
}
