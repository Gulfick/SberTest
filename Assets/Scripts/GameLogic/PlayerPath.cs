using UnityEngine;

public class PlayerPath : MonoBehaviour
{
    [SerializeField] private TriggerCallback _startCallback, _finishCallback;
    [SerializeField] private PlayerPathData _data;
    private PathState _pathState = PathState.Idle;

    private void Start()
    {
        _startCallback.Init("Player", OnEnterStart, null);
        _finishCallback.Init("Player", OnEnterEnd, null);
    }

    private void OnEnterStart()
    {
        if(_pathState != PathState.Idle)
            return;
        
        _pathState = PathState.Process;
        _data.OnStart?.Invoke();
    }
    
    private void OnEnterEnd()
    {
        if(_pathState != PathState.Process)
            return;
        
        _pathState = PathState.End;
        _data.OnEnd?.Invoke();
    }
    
    private enum PathState
    {
        Idle,
        Process,
        End
    }
}
