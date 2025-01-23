using Infrastructure;
using UnityEngine;
using Zenject;

namespace Player
{
    public class MoveController : MonoBehaviour
    {
        public float MovementSpeed;
        public float RotationSpeed;
        public CharacterController CharacterController;
        public Transform CameraTransform;
    
        private IInputService _inputService;
        private float _verticalRotation = 0;
    
        [SerializeField] private float _minClampVertical = -60;
        [SerializeField] private float _maxClampVertical = 90;

        [Inject]
        private void Constructor(IInputService inputService)
        {
            _inputService = inputService;
        }

        private void Start()
        {
    #if UNITY_STANDALONE
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    #endif
        }

        private void Update()
        {
            Vector3 dir = transform.right * _inputService.MoveAxis.x + transform.forward * _inputService.MoveAxis.y;
            CharacterController.Move(dir * MovementSpeed * Time.deltaTime);
        
            _verticalRotation -= _inputService.RotateAxis.y * RotationSpeed;
            _verticalRotation = RotationClamped(_verticalRotation);

            CameraTransform.localRotation = Quaternion.Euler(_verticalRotation, 0f, 0f);
        
            transform.Rotate(Vector3.up * _inputService.RotateAxis.x * RotationSpeed);
        }
    
        private float RotationClamped(float refRotation) => Mathf.Clamp(refRotation, _minClampVertical, _maxClampVertical);
    }
}