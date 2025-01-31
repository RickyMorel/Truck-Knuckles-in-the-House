using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnPointsManager : MonoBehaviour
{
    #region Editor Fields

    [SerializeField] private ItemSpawnData[] _itemAndSpawnLocacions;

    #endregion

    #region Private Fields

    private int _randomNumber;
    private List<Transform> _usedSpawnLocacions;

    #endregion

    void Start()
    {
        _usedSpawnLocacions = new List<Transform>();

        foreach (ItemSpawnData data in _itemAndSpawnLocacions)
        {
            List<Transform> validSpawnPoints = data.SpawnLocacions
                .Where(spawnPoint => spawnPoint != null && !_usedSpawnLocacions.Contains(spawnPoint))
                .ToList();

            if (validSpawnPoints.Count > 0)
            {
                Transform selectedSpawnPoint = validSpawnPoints[Random.Range(0, validSpawnPoints.Count)];
                Instantiate(data.ItemPrefab, selectedSpawnPoint.position, selectedSpawnPoint.rotation);
                _usedSpawnLocacions.Add(selectedSpawnPoint);
            }
        }
    }
    [Serializable]
    public class ItemSpawnData
    {
        public GameObject ItemPrefab;
        public Transform[] SpawnLocacions;
    }
}
