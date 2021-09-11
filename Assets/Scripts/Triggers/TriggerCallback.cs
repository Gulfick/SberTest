using System;
using UnityEngine;

public class TriggerCallback : MonoBehaviour
{
    private string _tag;
    private Action _onEnter;
    private Action _onExit;

    public void Init(string enteredTag, Action onEnter, Action onExit)
    {
        _tag = enteredTag;
        _onEnter = onEnter;
        _onExit = onExit;
    }

    public void RemoveCallback()
    {
        _tag = null;
        _onEnter = null;
        _onExit = null;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(_tag == null)
            return;
        
        if (other.CompareTag(_tag))
        {
            _onEnter?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(_tag == null)
            return;
        
        if (other.CompareTag(_tag))
        {
            _onExit?.Invoke();
        }
    }
}
