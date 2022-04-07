using UnityEngine;

public class SniperEquipment : Equipment
{
    [SerializeField] private Spectacless _spectacless;
    [SerializeField] private Bracers _rightBracer, _leftBracer;

    private void OnEnable()
    {
        EquipmentParts.Add(_spectacless);
        EquipmentParts.Add(_rightBracer);
        EquipmentParts.Add(_leftBracer);
    }
}