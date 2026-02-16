using System;
using System.Collections.Generic;
using UnityEngine;

public class Car : ARInteractableObject
{
    private static readonly int GoToIdle = Animator.StringToHash("GoToIdle");
    private static readonly int StartInteraction = Animator.StringToHash("StartInteraction");
    private Animator _animator;
    
    
    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
    }

    protected override void SetState(State state)
    {
        base.SetState(state);
        Debug.Log("Entra a car");
        switch (state)
        {
            case State.Idle:
                _animator.SetTrigger(GoToIdle);
                break;
            case State.Active:
                _animator.SetTrigger(StartInteraction);
                break;
        }
    }
    
}
