using Unity.VisualScripting;
using UnityEngine;

public class KeyPadButtons : MonoBehaviour
{
    #region Editor Fields

    [SerializeField] private SafePuzzle _safe;
    [SerializeField] private string _codeInsert;
    [SerializeField] private bool _isEnterButton;
    [SerializeField] private bool _isCancelButton;

    #endregion

    private void OnMouseDown()
    {
        if (_isEnterButton)
        {
            _safe.TryOpenSafe();
        }

        if (_isCancelButton)
        {
            _safe.ResetNumbers();
            return;
        }

        if (!_isEnterButton)
        {
            _safe.CheckResetSafe();
            _safe.ChangeNumber(_codeInsert);

        }
    }
}
