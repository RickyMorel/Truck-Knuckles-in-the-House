using System;
using System.Text;
using TMPro;
using UnityEngine;

public class Safepuzzle : MonoBehaviour
{
    public String Needednumber = "1449";
    public String Currentnumber;
    public bool OpenSafe;
    [SerializeField] TMP_Text _numbers;
    [SerializeField] public GameObject numbersObj;
    [SerializeField] public GameObject Accepted;
    [SerializeField] public GameObject Denied;
    [SerializeField] public GameObject Keypad;
    [SerializeField] public GameObject LightGreen;
    [SerializeField] public GameObject LightRed;

    private float _distance;

    [SerializeField] private Transform _safeDoor;
    [SerializeField] private Transform _player;

    [SerializeField] private Material _coloroff;
    [SerializeField] private Material _colorOnGreen;
    [SerializeField] private Material _colorOnRed;

    public bool CanPutInCode;

    [SerializeField] public int numsin;
    void Start()
    {
        
    }

    void Update()
    {
        _distance = Vector3.Distance(_player.position, _safeDoor.position);
        if (_distance > 2)
        {
           CanPutInCode = false;

            return;
        }
        else 
        {
            CanPutInCode = true;
        }
        _numbers.text = Currentnumber;

        if (Currentnumber == Needednumber)
        {
            Debug.Log("abc");
        }
        if (OpenSafe)
        {
            Debug.Log("cba");
        }
        if(Currentnumber == Needednumber && OpenSafe)
        {
            numbersObj.SetActive(false);
            Accepted.SetActive(true);
            Currentnumber = null;
            Keypad.transform.parent = _safeDoor;
            LightGreen.GetComponent<MeshRenderer>().material = _colorOnGreen;
            LightRed.GetComponent<MeshRenderer>().material = _coloroff;
            _safeDoor.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            _safeDoor.Rotate(0, 0, 40, Space.Self);
            OpenSafe = false;
        }
        else if (OpenSafe)
        {
            numbersObj.SetActive(false);
            Denied.SetActive(true);
            OpenSafe = false;
            Currentnumber = null;
            numsin = 0;
            return;
        }
       
    }
    
}
