using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NavigationComponent : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Coroutine _coroutine;
    private Vector3 _startPosition;
    private Transform _transform;
    public Action OnReached;

    private void Start()
    {
        Initialize();
    }

    protected virtual void Initialize()
    {
        _transform = transform;
        _agent = GetComponent<NavMeshAgent>();
        _startPosition = transform.position;
    }

    public void GoToPoint(Vector3 point)
    {
        _agent.SetDestination(point);
    }

    public void FollowTransform(Transform trans)
    {
        _coroutine = StartCoroutine(FollowTransformUpdate(trans));
    }

    private IEnumerator FollowTransformUpdate(Transform trans)
    {
        while (true)
        {
            _agent.SetDestination(trans.position);
            yield return new WaitForSeconds(0.1f);
            if(Vector3.Distance(_transform.position, trans.position) < 1)
                OnReached?.Invoke();
        }
    }

    public void StopFollow()
    {
        StopCoroutine(_coroutine);
    }

    public void ReturnToStart()
    {
        _agent.SetDestination(_startPosition);
    }
}
