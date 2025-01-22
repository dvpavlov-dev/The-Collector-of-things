using UnityEngine;

namespace Infrastructure
{
    public class MobileInputService : InputService
    {
        public override Vector2 MoveAxis => SimpleMoveAxis();
        public override Vector2 RotateAxis => SimpleRotateAxis();
        public override bool Interact => SimpleInput.GetButtonDown(BUTTON);

        private static Vector2 SimpleMoveAxis() => new(SimpleInput.GetAxis(HORIZONTAL), SimpleInput.GetAxis(VERTICAL));
        private static Vector2 SimpleRotateAxis() => new(SimpleInput.GetAxis(MOUSE_X), SimpleInput.GetAxis(MOUSE_Y));
    }
}