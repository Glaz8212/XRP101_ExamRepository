using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateType
{
    Idle, Attack
}

public class StateMachine
{
    private Dictionary<StateType, PlayerState> _stateContainer;
    public StateType CurrentType { get; private set; }
    private PlayerState CurrentState => _stateContainer[CurrentType];
    private float _changedTime;
    private float _stateChangeCooltime = 0.1f;

    public StateMachine(params PlayerState[] states)
    {
        _stateContainer = new Dictionary<StateType, PlayerState>();

        foreach (var s in states)
        {
            if (!_stateContainer.ContainsKey(s.ThisType))
            {
                _stateContainer.Add(s.ThisType, s);    
            }
            s.Machine = this;
        }

        CurrentType = states[0].ThisType;
        CurrentState.Enter();
        _changedTime = Time.time;
    }

    public void OnUpdate()
    {
        CurrentState.OnUpdate();
    }

    public void ChangeState(StateType state)
    {
        if (Time.time - _changedTime < _stateChangeCooltime)
            return;

        CurrentState.Exit();
        CurrentType = state;
        CurrentState.Enter();
    }
}
