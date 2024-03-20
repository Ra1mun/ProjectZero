

using UnityEngine;

namespace ZeroProject.Player.Jump.Realisation
{
    public class JumpNormalizedDirection : JumpDirection
    {
        //make mathematics formula 
        public override Vector2 Direction(Vector2 forward)
        {
            if (forward != Vector2.zero)
            {
                return new Vector2(0.5f, 0.5f);
            }
            
            return new Vector2(1f, 0f);
        }
    }
}