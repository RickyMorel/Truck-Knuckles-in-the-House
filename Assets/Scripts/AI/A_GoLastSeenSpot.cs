using UnityEngine;
using UnityEngine.AI;

public class A_GoLastSeenSpot : A_Base
{
    #region Editor Fields

    #endregion

    #region Private Variables

    private NavMeshAgent _agent;

    #endregion

    public override void Start()
    {
        base.Start();

        _agent = GetComponent<NavMeshAgent>();
    }

    public override void StartAction()
    {
        base.StartAction();
    }

    public override void DoAction()
    {
        CheckSwitchAction();
        GoToLastSeenSpot();
    }

    private void GoToLastSeenSpot()
    {
        _agent.SetDestination(_aiCues.PlayerLastSeenPosition);
    }

    public override void CheckSwitchAction()
    {
        base.CheckSwitchAction();

        if (_aiCues.Player) { _aiStateMachine.DoChase(); }

        float distanceFromLastSeenSpot = Vector3.Distance(_aiCues.PlayerLastSeenPosition, transform.position);

        if (distanceFromLastSeenSpot <= _agent.stoppingDistance) { _aiCues.SetPlayerLastSeenSpot(Vector3.zero); _aiStateMachine.DoSearch(); }
    }
}
