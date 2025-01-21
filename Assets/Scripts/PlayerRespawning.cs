using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerRespawning : MonoBehaviour
{
    #region Editor Fields

    [SerializeField] private Transform _respawnPosition;
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    [SerializeField] private TextMeshProUGUI _textOfDaysLeft;
    [SerializeField] private GameObject _backround;
    [SerializeField] private int lastDay = 5;
    [SerializeField] private GameObject _player;

    #endregion

    #region Private Propierties

    private int _currentDay;
    private CharacterController _playerCharacterController;

    #endregion
    private void Start()
    {
        _playerCharacterController = _player.GetComponent<CharacterController>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            
                StartCoroutine(RespawnPlayer());
        }
    }
    IEnumerator RespawnPlayer()
    {
        Debug.Log("Trying to respawn");
        _currentDay++;

        if (_currentDay > lastDay) yield break;

        _textMeshPro.enabled = true;
        _textOfDaysLeft.enabled = true;
        _backround.active = true;
        _textOfDaysLeft.text = " " + _currentDay + " ";
        _playerCharacterController.enabled = false;
        _player.transform.position = _respawnPosition.position;

        yield return new WaitForSeconds(2);

        _playerCharacterController.enabled = true;
        _textMeshPro.enabled = false;
        _textOfDaysLeft.enabled = false;
        _backround.active = false;
        Debug.Log("Respawned");
        yield return null;
    }
}
