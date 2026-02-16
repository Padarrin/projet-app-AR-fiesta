using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class ARInteractableObject : MonoBehaviour
{
    private List<ARInteractableObject> _interacables = new List<ARInteractableObject>();
    protected enum State
    {
        Idle,
        Active
    };
    protected State ARObjectState = State.Idle;
    
    // List of interactables I am interacting with
    // State of this ARObject
    // Get ARInteractableObject when trigger enters and exits
    // What happens when this object gets disable?
    // Update the State of this AR Object
    
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.TryGetComponent<ARInteractableObject>(out ARInteractableObject interactableObject))
        { 
            Debug.Log("Enter");
            AddInteractable(interactableObject);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.TryGetComponent<ARInteractableObject>(out ARInteractableObject interactableObject)) return;
        RemoveInteractable(interactableObject);
    }

    private void OnDisable()
    {
        foreach (var interactable in _interacables)
        {
            interactable.RemoveInteractable(this);
        }
        _interacables.Clear();
        SetState(State.Idle);
    }

    protected void AddInteractable(ARInteractableObject interactor)
    {
        _interacables.Add(interactor);
        SetState(State.Active);
    }

    protected void RemoveInteractable(ARInteractableObject interactor)
    {
        _interacables.Remove(interactor);
        if (_interacables.Count == 0) SetState(State.Idle);
    }
    protected virtual void SetState(State state)
    {
        ARObjectState = state;
    }

    
}
