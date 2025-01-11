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
    [SerializeField] private Rigidbody _safeDoorRb;
    [SerializeField] private Transform _player;
    [SerializeField] private Material _coloroff;
    [SerializeField] private Material _colorOnGreen;
    [SerializeField] private Material _colorOnRed;
    [SerializeField] private GameObject Accepted;
    [SerializeField] private GameObject Denied;
    [SerializeField] private GameObject _numbersObj;
    [SerializeField] private Rigidbody[] _keypadButtonRbs;

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
            OpenSafe();
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

    private void OpenSafe()
    {
        _numbersObj.SetActive(false);
        Accepted.SetActive(true);
        _currentNumber = null;
        _LightGreen.GetComponent<MeshRenderer>().material = _colorOnGreen;
        _LightRed.GetComponent<MeshRenderer>().material = _coloroff;
        _safeDoorRb.isKinematic = false;

        //Set button rbs to kinematic so they stay stuck to the door as it opens
        foreach (Rigidbody rb in _keypadButtonRbs)
        {
            rb.isKinematic = true;
        }
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
