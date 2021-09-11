using System.Collections.Generic;
using UnityEngine;

public class FoundGameLogic : MonoBehaviour
{
    [SerializeField] private PlayerData _playerData;
    [SerializeField] private FoundGameData _foundGameData;
    [SerializeField] private PlayerPathData _playerPathData;
    [SerializeField] private CursorController _cursorController;

    private void Start()
    {
        _cursorController.Lock();
        _foundGameData.EnemiesStatus = new Dictionary<string, bool>();
        foreach (var enemyLogic in FindObjectsOfType<EnemyLogic>())
        {
            _foundGameData.EnemiesStatus.Add(enemyLogic.name, false);
            enemyLogic.OnFound += OnFound;
            enemyLogic.GetComponent<DetectComponent>().OnReached += EndGame;
        }

        _playerPathData.OnEnd += EndGame;
    }

    private void EndGame()
    {
        _playerData.IsMove = false;
        _cursorController.Unlock();
        Time.timeScale = 0.001f;
        _foundGameData.OnEnd?.Invoke();
    }

    private void OnFound(string name, Vector3 pos)
    {
        _foundGameData.EnemiesStatus[name] = true;
    }
}
