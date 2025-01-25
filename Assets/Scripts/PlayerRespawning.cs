using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRespawning : MonoBehaviour
{
    #region Editor Fields

    [SerializeField] private Transform _respawnPosition;
    [SerializeField] private TextMeshProUGUI _textMeshPro;
    [SerializeField] private TextMeshProUGUI _textOfDaysLeft;
    [SerializeField] private TextMeshProUGUI _lastDayText;
    [SerializeField] private GameObject _background;
    [SerializeField] private int _lastDay = 5;
    [SerializeField] private GameObject _player;
    [SerializeField] private float _fadeDuration = 2.0f;
    [SerializeField] private Animator _canvasAnim;

    #endregion

    #region Private Propierties

    private int _currentDay;
    private CharacterController _playerCharacterController;
    private Image _backroundImage;

    #endregion

    #region Public Propierties

    public static PlayerRespawning Instance { get; private set; }

    #endregion

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        _playerCharacterController = _player.GetComponent<CharacterController>();
        _backroundImage = _background.GetComponent<Image>();

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            
                StartCoroutine(RespawnPlayerCoroutine());
        }
    }
    public IEnumerator RespawnPlayerCoroutine()
    {
        Debug.Log("Trying to respawn");
        _currentDay++;

        _textMeshPro.enabled = true;
        _background.active = true;

        _canvasAnim.Play("DayScreenFadeIn");

        if (IsLastDay()) yield break;

        _textOfDaysLeft.text = _currentDay.ToString();

        _playerCharacterController.enabled = false;
        _textOfDaysLeft.enabled = true;


        yield return new WaitForSeconds(4);

        _player.transform.position = _respawnPosition.position;

        _canvasAnim.Play("DayScreenFadeOut");

        _playerCharacterController.enabled = true;

        yield return new WaitForSeconds(1);

        DisableCanvasElements();

        yield return null;
    }

    private void DisableCanvasElements()
    {
        _textMeshPro.enabled = false;
        _background.active = false;
        _textOfDaysLeft.enabled = false;
        _lastDayText.enabled = false;
    }

    bool IsLastDay()
    {
        if (_currentDay > _lastDay)
        {
            _textMeshPro.text = "You Died";
            return false;
        }

        if (_currentDay == _lastDay)
        {
            _lastDayText.enabled = true;
            return true;
        }
        return true;

    }
    public void RespawnPlayer()
    {
        StartCoroutine(RespawnPlayerCoroutine());
    }
}
