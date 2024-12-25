using UnityEngine;

public class RoomArea : MonoBehaviour
{
    #region Private Variables

    private Collider _roomColiider;

    #endregion

    private void Start()
    {
        _roomColiider = GetComponent<Collider>();   
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerController>() == null) { return; }

        Debug.Log("Enter Room: " + other.gameObject.name);

        RoomManager.Instance.SetCurrentRoomPlayerIsAt(_roomColiider);
    }
}
