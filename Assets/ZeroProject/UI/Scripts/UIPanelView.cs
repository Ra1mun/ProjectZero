using UnityEditor.Search;
using UnityEngine;

namespace ZeroProject.UI.Realisation
{
    public abstract class UIPanelView : MonoBehaviour
    {
        public abstract void Show();
        public abstract void Hide();
    }
}