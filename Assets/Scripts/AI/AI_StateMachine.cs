using UnityEngine;

public class AI_StateMachine : MonoBehaviour
{
    #region Editor Fields

    [SerializeField] private A_Base[] _actions;

    #endregion

    #region Private Variables

    private A_Base _currentAction;

    #endregion

    void Start()
    {
        DoNewAction(_actions[2]);   
    }

    void Update()
    {
        if(!_currentAction) { return; }

        _currentAction.DoAction();   
    }

    private void DoNewAction(A_Base actionToDo)
    {
        actionToDo.StartAction();

        _currentAction = actionToDo;
    }

    public void DoPatrol() { DoNewAction(_actions[0]); }
    public void DoChase() { DoNewAction(_actions[1]); }
    public void DoSearch() { DoNewAction(_actions[2]); }
}
