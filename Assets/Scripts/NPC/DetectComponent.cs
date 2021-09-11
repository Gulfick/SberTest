using System.Collections;
using UnityEngine;

public class DetectComponent : NavigationComponent
{
    [SerializeField] private TriggerCallback _callback;
    [SerializeField] private string _detectedTag;
    [SerializeField] private Transform _followTransform;

    private Coroutine _coroutine;

    protected override void Initialize()
    {
        base.Initialize();
        _callback.Init(_detectedTag, Detected, EndFollow );
        GetComponent<BaseEnemy>().OnFound += OnEnd;
    }

    private void Detected()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }

        FollowTransform(_followTransform);
    }

    private void EndFollow()
    {
        _coroutine = StartCoroutine(FollowTimer());
    }

    private IEnumerator FollowTimer()
    {
        yield return new WaitForSeconds(3);
        StopFollow();
        ReturnToStart();
    }

    public void StopDetecting()
    {
        StopAllCoroutines();
        _coroutine = null;
        _callback.RemoveCallback();
    }

    private void OnEnd(string name, Vector3 point)
    {
        StopDetecting();
        GoToPoint(point);
    }
}
