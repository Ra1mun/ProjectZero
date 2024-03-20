
using UnityEngine;

namespace ZeroProject.Player.Jump
{
    public abstract class JumpDirection
    {
        public abstract Vector2 Direction(Vector2 forward);
    }
}