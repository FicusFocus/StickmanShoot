using UnityEngine;
using UnityEngine.EventSystems;


public class PlayerMower : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    [SerializeField] private Player _player;
    [SerializeField] private float _speed;

    public void OnBeginDrag(PointerEventData eventData)
    {    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))
        {
            if (eventData.delta.x > 0)
                _player.transform.position += Vector3.right * _speed * Time.deltaTime;
            else
                _player.transform.position += Vector3.left * _speed * Time.deltaTime;
        }
    }
}
