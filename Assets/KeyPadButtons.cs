using Unity.VisualScripting;
using UnityEngine;

public class KeyPadButtons : MonoBehaviour
{
    [SerializeField] Safepuzzle safe;
    [SerializeField] string codeinsert;
    [SerializeField] bool isenter;
    [SerializeField] bool iscancel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        if (safe.numsin == 4 && !isenter)
        {
            safe.Currentnumber = null;
            safe.numsin = 0;
        }
        if (isenter)
        {
            safe.OpenSafe = true;
            return;
        }
        else if (isenter && safe.Currentnumber != safe.Needednumber)
        {
            safe.Currentnumber = null;
        }
        if (iscancel)
        {
            safe.Currentnumber = null;
            safe.numbersObj.SetActive(true);
            safe.Denied.SetActive(false);
            safe.numsin = 0;
            return;
        }
        if (safe.CanPutInCode && !isenter)
        {
            safe.numsin++;
            safe.Currentnumber = safe.Currentnumber + codeinsert;
            safe.numbersObj.SetActive(true);
            safe.Denied.SetActive(false);

        }
    }
}
