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

    void DoNewAction(A_Base actionToDo)
    {
        actionToDo.StartAction();

        _currentAction = actionToDo;
    }
}
