using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour, Iinteractable
{
    public bool useEvents;
    public string prompMessage;

    public void interact()
    {
        if (useEvents)
            GetComponent<InteractionEvent>().OnInteract.Invoke();

        Interact();
    }

    protected virtual void Interact()
    {

    }
}
