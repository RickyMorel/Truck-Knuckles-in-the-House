using UnityEngine;
using UnityEngine.Events;

public class TriggerEvents : MonoBehaviour
{
    #region Editor Fields

    [SerializeField] private UnityEvent<Collider> _onTriggerEnter;
    [SerializeField] private UnityEvent<Collider> _onTriggerEnd;

    #endregion

    private void OnTriggerEnter(Collider other)
    {
        _onTriggerEnter?.Invoke(other);
    }

    private void OnTriggerEnd(Collider other)
    {
        _onTriggerEnd?.Invoke(other);
    }
}
