using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class AmmoPack : MonoBehaviour
{
    [SerializeField] private TMP_Text _ammoCoutText;
    [SerializeField] private Transform _pack;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private int _ammoInPack;

    private Collider _collider;

    private void Start()
    {
        _collider = GetComponent<Collider>();
        _collider.isTrigger = true;
        _ammoCoutText.text = _ammoInPack.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Chamber chamber))
        {
            chamber.TakeAmmo(_ammoInPack);
            Destroy(gameObject);
        }
    }
}