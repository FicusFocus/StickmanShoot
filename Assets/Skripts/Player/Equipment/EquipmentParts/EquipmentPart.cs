using UnityEngine;

public abstract class EquipmentPart : MonoBehaviour
{
    public void SetEnabledState(bool state)
    {
        gameObject.SetActive(state);
    }
}
