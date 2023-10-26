using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceTransition : Transition
{
    [SerializeField] private float _endPosition;
    [SerializeField] private int _endPositionSpread;

    private float _startPosition;
    private Transform _currentPosition;
    private float _distance;

    private void Start()
    {
        _currentPosition = GetComponent<Transform>();
    }

    private void OnEnable()
    {
        _endPosition += Random.Range(-_endPositionSpread, _endPositionSpread);
        _startPosition = GetComponent<Transform>().position.y;
    }

    private void Update()
    {
        _distance = _startPosition - _currentPosition.position.y;

        if (_distance >= _endPosition)
        {
            NeedTransit = true;
        }
    }
}
