using UnityEngine;

namespace Infrastructure
{
    public class StandaloneInputService : InputService
    {
        public override Vector2 MoveAxis => UnityMoveAxis();
        public override Vector2 RotateAxis => UnityRotateAxis();
        public override bool Interact => Input.GetButtonDown(BUTTON);

        private static Vector2 UnityMoveAxis() => new(Input.GetAxis(HORIZONTAL), Input.GetAxis(VERTICAL));
        private static Vector2 UnityRotateAxis() => Input.GetMouseButton(0) ? new Vector2(Input.GetAxis(MOUSE_X), -Input.GetAxis(MOUSE_Y)) : Vector2.zero;

    }
}