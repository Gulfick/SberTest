using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyLogic : BaseEnemy
{
    [SerializeField] private Image _statusImage;
    [SerializeField] private Transform _endPoint;
    [SerializeField] private EnemyData _enemyData;
    private float _lookTmr;
    private bool _isFound;
    private Coroutine _timerCoroutine;
    private DetectComponent _detect;
    

    private void Start()
    {
        _detect = GetComponent<DetectComponent>();
    }

    public void StartTimer()
    {
        if(_isFound)
            return;
        if(_timerCoroutine != null)
            StopCoroutine(_timerCoroutine);
        _timerCoroutine = StartCoroutine(TimerCoroutine());
    }

    public void StopTimer()
    {
        if(_isFound)
            return;
        if(_timerCoroutine != null)
            StopCoroutine(_timerCoroutine);
        _timerCoroutine = StartCoroutine(DontLookTimer());
    }

    private IEnumerator TimerCoroutine()
    {
        while (true)
        {
            _lookTmr += Time.fixedDeltaTime;
            _statusImage.fillAmount = _lookTmr / _enemyData.TimeToFound;
            if (_lookTmr >= _enemyData.TimeToFound)
            {
                Found();
                yield break;
            }

            yield return new WaitForFixedUpdate();
        }
    }

    private IEnumerator DontLookTimer()
    {
        yield return new WaitForSeconds(_enemyData.TimeToMinus);
        while (_lookTmr > 0)
        {
            _lookTmr -= Time.fixedDeltaTime;
            _statusImage.fillAmount = _lookTmr / _enemyData.TimeToFound;
            yield return new WaitForFixedUpdate();
        }

        _lookTmr = 0;
    }

    private void Found()
    {
        _detect.StopDetecting();
        _detect.GoToPoint(_endPoint.position);
        _isFound = true;
        _timerCoroutine = null;
        _isFound = true;
        _statusImage.color = Color.green;
        OnFound?.Invoke(name, _endPoint.position);
    }
}
