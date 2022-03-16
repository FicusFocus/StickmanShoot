using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMover : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    private Player _traget;
    private float _sideSpeed;

    public void OnBeginDrag(PointerEventData eventData)
    {
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))
        {
            if (eventData.delta.x > 0)
                _traget.transform.position += Vector3.right * _sideSpeed * Time.deltaTime;
            else
                _traget.transform.position += Vector3.left * _sideSpeed * Time.deltaTime;
        }
    }

    public void SetSideSpeedValue(float value)
    {
        _sideSpeed = value;
    }

    public void SetTargetToMove(Player target)
    {
        _traget = target;
    }
}
