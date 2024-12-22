using UnityEngine;

public class AI_Cues : MonoBehaviour
{
    #region Editor Fields

    [SerializeField] private PlayerController _player;

    #endregion

    #region Public Properties

    public PlayerController Player => _player;

    #endregion

    public void SetPlayer(PlayerController player)
    {
        _player = player;
    }
}
