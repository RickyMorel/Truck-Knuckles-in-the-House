using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class A_Patrol : A_Base
{
    #region Editor Fields

    #endregion

    #region Private Variables

    private List<Waypoint> _waypoints = new List<Waypoint>();
    private NavMeshAgent _agent;
    private int _currentWaypointIndex;

    #endregion

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    public override void StartAction()
    {
        base.StartAction();

        _waypoints = FindObjectsOfType<Waypoint>().ToList();
    }

    public override void DoAction()
    {
        Debug.Log("currentIndex: " + _currentWaypointIndex);
        PatrolToWaypoint();
    }

    private void PatrolToWaypoint()
    {
        float distanceFromWaypoint = Vector3.Distance(_waypoints[_currentWaypointIndex].transform.position, transform.position);

        _agent.SetDestination(_waypoints[_currentWaypointIndex].transform.position);

        if (distanceFromWaypoint > _agent.stoppingDistance) { return; }

        _currentWaypointIndex++;

        if (_currentWaypointIndex >= _waypoints.Count) { _currentWaypointIndex = 0; }
    }

    public override void CheckSwitchAction()
    {
        base.CheckSwitchAction();
    }
}
