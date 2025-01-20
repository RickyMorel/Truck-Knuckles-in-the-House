using UnityEngine;

public class Door : MonoBehaviour
{
    #region Editor Fields

    [SerializeField] private Rigidbody _doorRb;
    [SerializeField] private Transform _snapPoint1;
    [SerializeField] private Transform _snapPoint2;
    private float _distance;

    #endregion

    private void Start()
    {
        
    }

    public void Open()
    {
        //Play door unlock sfx

        _doorRb.isKinematic = false;
    }

    public void OnAreaEnter(Collider collider, GameObject triggerObj)
    {
        Debug.Log("OnAreaEnter");
        if (!collider.TryGetComponent<AI_StateMachine>(out AI_StateMachine aI_State)) { return; }

        Debug.Log("OnAreaEnter AIII");

        if (IsOpen()) { return; }

        Debug.Log("OnAreaEnter AII NOT OPENNN");

        float snapPoint1Distance = Vector3.Distance(aI_State.transform.position, _snapPoint1.position);
        float snapPoint2Distance = Vector3.Distance(aI_State.transform.position, _snapPoint2.position);

        Transform closestSnapPoint = snapPoint1Distance < snapPoint2Distance ? _snapPoint1 : _snapPoint2;

        aI_State.DoOpenDoor(closestSnapPoint, this);
    }

    private bool IsOpen()
    {
        return !_doorRb.isKinematic;
    }

    public void DestroyDoor()
    {
        _doorRb.gameObject.SetActive(false);
    }
}
