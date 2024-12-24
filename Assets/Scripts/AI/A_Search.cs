using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class A_Search : A_Base
{
    #region Editor Fields

    [SerializeField] private int _maxSearchAmount = 2;

    #endregion

    #region Private Variables

    private List<SearchPoint> _relevantSearchPoints = new List<SearchPoint>();
    private NavMeshAgent _agent;
    private int _currentSearchIndex;
    private int _currentSearchAmount;
    private bool _isSearching;

    #endregion

    public override void Start()
    {
        base.Start();

        _agent = GetComponent<NavMeshAgent>();
    }

    public override void StartAction()
    {
        base.StartAction();

        _currentSearchAmount = 0;
        _relevantSearchPoints = FindObjectsOfType<SearchPoint>().ToList();
    }

    public override void DoAction()
    {
        if(_isSearching) { return; }

        CheckSwitchAction();

        PatrolToSearchPoint();
    }

    private void PatrolToSearchPoint()
    {
        float distanceFromSearchPoint = Vector3.Distance(_relevantSearchPoints[_currentSearchIndex].transform.position, transform.position);

        _agent.SetDestination(_relevantSearchPoints[_currentSearchIndex].transform.position);

        if (distanceFromSearchPoint <= _agent.stoppingDistance) { StartCoroutine(SearchCoroutine()); return; }
    }


    private IEnumerator SearchCoroutine()
    {
        _isSearching = true;

        Debug.Log("Searching....");

        yield return new WaitForSeconds(2f);

        Debug.Log("Finished Searching");

        _isSearching = false;

        _currentSearchAmount++;

        _currentSearchIndex++;

        if (_currentSearchIndex >= _relevantSearchPoints.Count) { _currentSearchIndex = 0; }
    }

    public override void CheckSwitchAction()
    {
        base.CheckSwitchAction();

        if(_aiCues.Player) { _aiStateMachine.DoChase(); }
        else if (_currentSearchAmount >= _maxSearchAmount) { _aiStateMachine.DoPatrol(); }
    }
}
