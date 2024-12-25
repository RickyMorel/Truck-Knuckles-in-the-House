using UnityEngine;

public class AI_Cues : MonoBehaviour
{
    #region Editor Fields

    [SerializeField] private PlayerController _player;
    [SerializeField] private Vector3 _playerLastSeenPosition;

    #endregion

    #region Private Variables


    #endregion

    #region Public Properties

    public PlayerController Player => _player;
    public Vector3 PlayerLastSeenPosition => _playerLastSeenPosition;  

    #endregion

    public void SetPlayer(PlayerController player)
    {
        _player = player;
    }

    public void SetPlayerLastSeenSpot(Vector3 seenPosition)
    {
        _playerLastSeenPosition = seenPosition;
    }
}
