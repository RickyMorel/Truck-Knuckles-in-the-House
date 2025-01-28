using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointsManager : MonoBehaviour
{
    #region Editor Fields

    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private List<GameObject> _spawnableObjects;
    [SerializeField] Dictionary<Transform[], GameObject> _spawnableObjectsDict;
    #endregion

    #region Private Fields

    private int _randomNumber;

    #endregion
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (Transform spawntrans in _spawnPoints)
        {
            _randomNumber = Random.Range(0, _spawnPoints.Length);
            Instantiate(_spawnableObjects[_randomNumber],spawntrans.position, _spawnableObjects[_randomNumber].transform.rotation);
            spawntrans.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [SerializeField]
    public class diccionary
    {
        public Transform _ObjSpawns;
        public GameObject Obj;
    }
}
