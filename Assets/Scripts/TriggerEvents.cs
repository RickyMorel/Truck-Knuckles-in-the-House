using UnityEngine;
using UnityEngine.Events;

public class TriggerEvents : MonoBehaviour
{
    #region Editor Fields

    [SerializeField] private UnityEvent<Collider,GameObject> _onTriggerEnter;
    [SerializeField] private UnityEvent<Collider,GameObject> _onTriggerExit;

    #endregion

    private void OnTriggerEnter(Collider other)
    {
        _onTriggerEnter?.Invoke(other,gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        _onTriggerExit?.Invoke(other,gameObject);
    }
}
