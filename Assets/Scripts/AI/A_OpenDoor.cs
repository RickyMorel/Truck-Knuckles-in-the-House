using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class A_OpenDoor : A_Base
{
    #region Editor Fields

    [SerializeField] private float _minOpenDistance = 2f;

    #endregion

    #region Private Variables

    private NavMeshAgent _agent;
    private Transform _currentSnapPoint;
    private Door _currentDoor;
    private bool _isOpeningDoor;

    #endregion

    public override void Start()
    {
        base.Start();

        _agent = GetComponent<NavMeshAgent>();
    }

    public override void StartAction(Dictionary<string, object> data = null)
    {
        base.StartAction(data);

        _currentSnapPoint = (Transform)data["snapPoint"];
        _currentDoor = (Door)data["door"];
    }

    public override void DoAction()
    {
        if (_isOpeningDoor) { return; }

        OpenDoor(_currentSnapPoint, _currentDoor);
    }

    private void OpenDoor(Transform snapPoint, Door door)
    {
        float distanceFromDoor = Vector3.Distance(snapPoint.position, transform.position);

        _agent.SetDestination(snapPoint.position);

        if (distanceFromDoor <= _minOpenDistance) { StartCoroutine(OpenDoorCoroutine(door)); }
    }

    private IEnumerator OpenDoorCoroutine(Door door)
    {
        _isOpeningDoor = true;

        Debug.Log("Open Door!");

        _agent.isStopped = true;

        _agent.velocity = Vector3.zero;

        _aiStateMachine.Anim.Play("UnlockDoor", 0);

        yield return new WaitForSeconds(3.13f);

        _isOpeningDoor = false;

        _agent.isStopped = false;

        door.Open();

        _aiStateMachine.DoPrevAction();
    }


    public override void CheckSwitchAction()
    {
        base.CheckSwitchAction();
    }
}
