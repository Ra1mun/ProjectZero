using UnityEngine;

namespace ZeroProject.UI.Realisation
{
    public class UIRoot : MonoBehaviour
    {
        public RectTransform PoolContainer => poolContainer;
        public RectTransform Container => container;
        public Canvas Canvas => canvas;
        
        [SerializeField] private RectTransform poolContainer;
        [SerializeField] private RectTransform container;
        [SerializeField] private Canvas canvas;
    }
}