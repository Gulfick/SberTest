using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
    [SerializeField] private Transform _camera;

    private EnemyLogic _enemy;
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(new Ray(_camera.position, _camera.forward), out hit, 15, LayerMask.GetMask("Enemy")))
        {
            if(_enemy != null)
                return;
            _enemy = hit.transform.GetComponent<EnemyLogic>();
            _enemy.StartTimer();
            _enemy.StartTimer();
        }
        else if (_enemy != null)
        {
            _enemy.StopTimer();
            _enemy = null;
        }
    }
}
