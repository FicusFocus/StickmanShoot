using System.Collections.Generic;
using UnityEngine;

public class PlatformRullController : MonoBehaviour
{
    [SerializeField] private Platform _template;
    [SerializeField] private Transform _startPosition;
    [SerializeField] private Transform _platformsContainer;
    [SerializeField] private int _platformCount;
    [SerializeField] private int _maxActivePlatformCount;

    private List<Platform> _platforms = new List<Platform>();
    private int _activePlatformsCount;
    private float _timeAfterLastSpawn = 0;
    private float _spawnDeley;
    private bool _needSpawn = false;

    private void OnDisable()
    {
        foreach (var platform in _platforms)
        {
            platform.PlatformDisativated -= OnPlatformDisactivated;
        }
    }

    private void Start()
    {
        _platforms = InstantiatePlatformsPull(_platformCount);
        ActiveateNewPlatform();
        _spawnDeley = (_template.Speed * 2) - 0.2f;
    }

    private void Update()
    {
        _timeAfterLastSpawn += Time.deltaTime;

        if (_activePlatformsCount < _maxActivePlatformCount)
            _needSpawn = true;

        if (_needSpawn && _timeAfterLastSpawn >= _spawnDeley)
        {
            ActiveateNewPlatform();
            _needSpawn = false;
            _timeAfterLastSpawn = 0;
        }
    }

    private List<Platform> InstantiatePlatformsPull(int platformCount)
    {
        var platforms = new List<Platform>();

        for (int i = 0; i < platformCount; i++)
        {
            var newPlatform = Instantiate(_template, _startPosition.position, Quaternion.identity, _platformsContainer);
            newPlatform.PlatformDisativated += OnPlatformDisactivated;
            newPlatform.enabled = false;
            platforms.Add(newPlatform);
        }

        return platforms;
    }

    private void ActiveateNewPlatform()
    {
        foreach (var platform in _platforms)
        {
            if (platform.enabled == false)
            {
                platform.enabled = true;
                _activePlatformsCount++;
                return;
            }
        }
    }

    private void OnPlatformDisactivated()
    {
        _activePlatformsCount--;
    }
}
