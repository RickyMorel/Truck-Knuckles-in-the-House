using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_StateMachine : MonoBehaviour
{
    #region Editor Fields

    [SerializeField] private A_Base[] _actions;

    #endregion

    #region Private Variables

    private A_Base _currentAction;
    private AI_Cues _aiCues;
    private Animator _anim;
    private NavMeshAgent _agent;
    private A_Base _prevAction;

    private float gizmoTimer = 0.0f;

    #endregion

    #region Public Properties

    public Animator Anim => _anim;

    #endregion

    void Start()
    {
        _aiCues = GetComponent<AI_Cues>();
        _anim = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();

        DoNewAction(_actions[0]);   
    }

    void Update()
    {
        Animate();

        if(!_currentAction) { return; }

        _currentAction.DoAction();

        if (gizmoTimer > 0)
        {
            gizmoTimer -= Time.deltaTime;
        }
    }

    private void Animate()
    {
        _anim.SetFloat("Moving", _agent.velocity.magnitude / _agent.speed);
    }

    private void DoNewAction(A_Base actionToDo, Dictionary<string, object> data = null)
    {
        _prevAction = _currentAction;

        actionToDo.StartAction(data);

        _currentAction = actionToDo;
    }

    public void DoPrevAction()
    {
        _prevAction.StartAction();

        _currentAction = _prevAction;
    }

    public void DoPatrol() { DoNewAction(_actions[0]); }

    public void DoChase() { DoNewAction(_actions[1]); }
    public void DoSearch() { DoNewAction(_actions[2]); }
    public void DoGoToPlayerLastSeenSpot() 
    {
        Vector3 lastSeenSpot = FindObjectOfType<PlayerController>().transform.position;

        _aiCues.SetPlayerLastSeenSpot(lastSeenSpot); 

        DoNewAction(_actions[3]);

        gizmoTimer = 2f;
    }
    public void DoOpenDoor(Transform closestSnapPoint, Door door) 
    {
        if(_currentAction == _actions[4]) { return; }

        Dictionary<string, object> data = new Dictionary<string, object>();
        data["snapPoint"] = closestSnapPoint;
        data["door"] = door;

        DoNewAction(_actions[4], data); 
    }

    void OnDrawGizmos()
    {
        if(gizmoTimer <= 0.0f) { return; }

        Vector3 lastSeenSpot = _aiCues.PlayerLastSeenPosition;

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(lastSeenSpot, 0.5f);
    }
}
