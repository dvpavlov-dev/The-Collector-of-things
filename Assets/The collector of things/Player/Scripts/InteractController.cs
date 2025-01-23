using Infrastructure;
using UnityEngine;
using Zenject;

public class InteractController : MonoBehaviour
{
    public LayerMask LayerAtInteractItems;
    public Transform CameraTransform;
    
    private IInputService _inputService;
    private GameObject _capturedItem;
    
    [Inject]
    private void Constructor(IInputService inputService)
    {
        _inputService = inputService;
    }

    void Update()
    {
        if (_inputService.Interact)
        {
            if (_capturedItem != null)
            {
                Rigidbody rb = _capturedItem.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.isKinematic = false;
                    rb.useGravity = true;
                }

                _capturedItem = null;
            }
            else
            {
                Ray raycast = new Ray(CameraTransform.transform.position, CameraTransform.transform.forward);
                
                if (Physics.Raycast(raycast, out RaycastHit hit, 10, LayerAtInteractItems))
                {
                    _capturedItem = hit.collider.gameObject;

                    Rigidbody rb = _capturedItem.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.isKinematic = true;
                        rb.useGravity = false;
                    }
                }
            }
        }
    }

    private void LateUpdate()
    {
        if (_capturedItem != null)
        {
            _capturedItem.transform.position = CameraTransform.transform.position + CameraTransform.transform.forward;
        }
    }
}
