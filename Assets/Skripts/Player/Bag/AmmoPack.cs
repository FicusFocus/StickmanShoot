using TMPro;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class AmmoPack : MonoBehaviour
{
    [SerializeField] private int _ammoInPack;
    [SerializeField] private TMP_Text _ammoCoutText;
    [SerializeField] private float _rotateCpeed;
    [SerializeField] private Transform _pack;

    private void Start()
    {
        _ammoCoutText.text = _ammoInPack.ToString();
    }

    private void Update()
    {
     //   _pack.rotation.y
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Chamber chamber))
            chamber.TakeAmmo(_ammoInPack);
    }
}