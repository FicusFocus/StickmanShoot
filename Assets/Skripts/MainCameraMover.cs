using UnityEngine;

public class MainCameraMover : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private float _zDistanceTotarget;

    private void Update()
    {
        if (_target != null)
            Setposition();
    }

    private void Setposition()
    {
        float xPosition = transform.position.x;
        float yPosition = transform.position.y;
        float zPosition = _target.transform.position.z - _zDistanceTotarget;

        Vector3 newPosition = new Vector3(xPosition, yPosition, zPosition);

        transform.position = newPosition;
    }
}
