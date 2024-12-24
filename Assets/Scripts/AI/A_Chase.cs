using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class A_Chase : A_Base
{
    #region Editor Fields

    #endregion

    #region Private Variables

    private NavMeshAgent _agent;
    private bool _isAttacking;

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
        if(_isAttacking) { return; }

        CheckSwitchAction();

        if(!_aiCues.Player) { return; }

        ChasePlayer();
    }

    private void ChasePlayer()
    {
        float distanceFromPlayer = Vector3.Distance(_aiCues.Player.transform.position, transform.position);

        _agent.SetDestination(_aiCues.Player.transform.position);

        if (distanceFromPlayer <= _agent.stoppingDistance) { StartCoroutine(AttackPlayer()); }
    }

    private IEnumerator AttackPlayer()
    {
        _isAttacking = true;

        Debug.Log("ATTACK!");

        yield return new WaitForSeconds(4f);

        _isAttacking = false;
    }

    public override void CheckSwitchAction()
    {
        base.CheckSwitchAction();

        if(!_aiCues.Player) { _aiStateMachine.DoSearch(); }
    }
}
