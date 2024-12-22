using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class A_Search : A_Base
{
    #region Editor Fields

    #endregion

    #region Private Variables

    private List<SearchPoint> _relevantSearchPoints = new List<SearchPoint>();
    private NavMeshAgent _agent;
    private int _currentSearchIndex;
    private bool _isSearching;

    #endregion

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    public override void StartAction()
    {
        base.StartAction();

        _relevantSearchPoints = FindObjectsOfType<SearchPoint>().ToList();
    }

    public override void DoAction()
    {
        if(_isSearching) { return; }

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

        _currentSearchIndex++;

        if (_currentSearchIndex >= _relevantSearchPoints.Count) { _currentSearchIndex = 0; }
    }

    public override void CheckSwitchAction()
    {
        base.CheckSwitchAction();
    }
}
