using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class A_Chase : A_Base
{
    #region Editor Fields

    #endregion

    #region Private Variables

    private NavMeshAgent _agent;
    private PlayerController _player;
    private bool _isAttacking;

    #endregion

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _player = FindObjectOfType<PlayerController>();
    }

    public override void StartAction()
    {
        base.StartAction();
    }

    public override void DoAction()
    {
        if(_isAttacking) { return; }

        ChasePlayer();
    }

    private void ChasePlayer()
    {
        float distanceFromPlayer = Vector3.Distance(_player.transform.position, transform.position);

        _agent.SetDestination(_player.transform.position);

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
    }
}
