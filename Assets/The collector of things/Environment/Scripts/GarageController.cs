using UnityEngine;
using DG.Tweening;

public class GarageController : MonoBehaviour
{
    [SerializeField] private Transform _leftDoor;
    [SerializeField] private Transform _rightDoor;
    
    private void Start()
    {
        _leftDoor.DORotate(new Vector3(0, 120, 0), 3).SetEase(Ease.OutBounce);
        _rightDoor.DORotate(new Vector3(0, -120, 0), 3).SetEase(Ease.OutBounce);
    }
}
