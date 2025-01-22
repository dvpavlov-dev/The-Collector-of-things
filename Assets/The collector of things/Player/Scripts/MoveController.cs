using Infrastructure;
using UnityEngine;
using Zenject;

public class MoveController : MonoBehaviour
{
    public float MovementSpeed;
    public float RotationSpeed;
    public CharacterController CharacterController;
    public Transform CameraTransform;
    private IInputService _inputService;
    
    [Inject]
    private void Constructor(IInputService inputService)
    {
        _inputService = inputService;
    }

    private void Update()
    {
        Vector3 dir = transform.right * _inputService.MoveAxis.x + transform.forward * _inputService.MoveAxis.y;
        CharacterController.Move(dir * MovementSpeed * Time.deltaTime);
        
        transform.Rotate(Vector3.up * _inputService.RotateAxis.x * RotationSpeed);
        CameraTransform.Rotate(Vector3.right * _inputService.RotateAxis.y * RotationSpeed);
    }
}
