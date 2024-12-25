using System.Linq;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    #region Editor Fields

    [SerializeField] private Room[] _rooms;

    #endregion

    #region Private Properties

    [SerializeField] private Room _currentRoomPlayerIsAt;
    private Room _currentRoomAiIsAt;

    #endregion

    #region Public Properties

   [SerializeField] public static RoomManager Instance { get; private set; }
    public Room CurrentRoomPlayerIsAt => _currentRoomPlayerIsAt;

    #endregion

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void SetCurrentRoomPlayerIsAt(Collider areaColiider)
    {
        Room currentRoom = _rooms.First(x => x.AreaCollider == areaColiider);

        _currentRoomPlayerIsAt = currentRoom;
    }

    [System.Serializable]
    public class Room
    {
        public Collider AreaCollider;
        public SearchPoint[] SearchPoints;
        public Waypoint[] Waypoints;
    }
}
