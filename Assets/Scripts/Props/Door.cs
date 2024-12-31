using UnityEngine;

public class Door : MonoBehaviour
{
    #region Editor Fields

    [SerializeField] private GameObject _doorObj;
    [SerializeField] private Transform _snapPoint1;
    [SerializeField] private Transform _snapPoint2;
    private float _distance;

    #endregion

    private void Start()
    {
        
    }

    public void OnAreaEnter()
    {

    }

    public void DestroyDoor()
    {
        _doorObj.SetActive(false);
    }
}
