using System.Collections.Generic;
using UnityEngine;

public abstract class Equipment : MonoBehaviour
{
    protected List<EquipmentPart> EquipmentParts = new List<EquipmentPart>();

    public void SetEquipmentEnabled(bool value)
    {
        foreach (EquipmentPart equipmentPart in EquipmentParts)
            equipmentPart.gameObject.SetActive(value);
    }
}
