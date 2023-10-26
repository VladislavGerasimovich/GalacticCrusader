using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;

    private State _currentState;

    public State Current => _currentState;

    public void Start()
    {
        Reset(_firstState);
    }

    public void Update()
    {
        if(_currentState == null)
        {
            return;
        }

        var nextState = _currentState.GetNextTransition();

        if(nextState != null)
        {
            Transit(nextState);
        }
    }

    private void Reset(State startState)
    {
        _currentState = startState;

        if(_currentState != null)
        {
            _currentState.Enter();
        }
    }

    private void Transit(State nextState)
    {
        if(_currentState != null)
        {
            _currentState.Exit();
        }

        _currentState = nextState;

        if(nextState != null)
        {
            nextState.Enter();
        }
    }
}
