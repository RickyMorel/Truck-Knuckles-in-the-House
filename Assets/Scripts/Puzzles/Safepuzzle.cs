using System;
using System.Text;
using TMPro;
using UnityEngine;
using static UnityEngine.VFX.VFXTypeAttribute;

public class SafePuzzle : MonoBehaviour
{

    #region Editor Fields

    [SerializeField] private TMP_Text _numbers;
    [SerializeField] private GameObject _Keypad;
    [SerializeField] private GameObject _LightGreen;
    [SerializeField] private GameObject _LightRed;
    [SerializeField] private Transform _safeDoor;
    [SerializeField] private Transform _player;
    [SerializeField] private Material _coloroff;
    [SerializeField] private Material _colorOnGreen;
    [SerializeField] private Material _colorOnRed;
    [SerializeField] private GameObject Accepted;
    [SerializeField] private GameObject Denied;
    [SerializeField] private GameObject _numbersObj;

    #endregion

    #region Priveat Propiertie

    private string _needednumber = "1449";
    private string _currentNumber;
    private int _inputCounter;

    #endregion

    public void UpdateText()
    {
        _numbers.text = _currentNumber;
    }
    public void TryOpenSafe()
    {
        if (_currentNumber == _needednumber)
        {
            _numbersObj.SetActive(false);
            Accepted.SetActive(true);
            _currentNumber = null;
            _Keypad.transform.parent = _safeDoor;
            _LightGreen.GetComponent<MeshRenderer>().material = _colorOnGreen;
            _LightRed.GetComponent<MeshRenderer>().material = _coloroff;
            _safeDoor.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            _safeDoor.Rotate(0, 0, 40, Space.Self);
        }
        else 
        {
            _numbersObj.SetActive(false);
            Denied.SetActive(true);
            _currentNumber = null;
            _inputCounter = 0;
        }

        UpdateText();
    }
    public void ResetNumbers()
    {
        _currentNumber = null;
        _numbersObj.SetActive(true);
        Denied.SetActive(false);
        _inputCounter = 0;
        UpdateText();
    }
    public void CheckResetSafe()
    {
        if (_inputCounter < 4) return;

        _currentNumber = null;
        _inputCounter = 0;
        UpdateText();
    }
    public void ChangeNumber(string input)
    {

        _inputCounter++;
        _currentNumber = _currentNumber + input;
        _numbersObj.SetActive(true);
        Denied.SetActive(false);
        UpdateText();
    }
}
