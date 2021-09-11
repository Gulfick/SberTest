using TMPro;
using UnityEngine;

public class FoundGameEndUI : MonoBehaviour
{
    [SerializeField] private GameObject _window;
    [SerializeField] private GameObject _enemyStatusPrefab;
    [SerializeField] private TextMeshProUGUI _endStatus;
    [SerializeField] private RectTransform _enemyStatusParent;
    [SerializeField] private FoundGameData _foundGameData;

    private void Start()
    {
        _foundGameData.OnEnd += ShowEndScreen;
    }

    private void ShowEndScreen()
    {
        _window.SetActive(true);
        _endStatus.text = _foundGameData.EndString();
        foreach (var status in _foundGameData.EnemiesStatus)
        {
            Instantiate(_enemyStatusPrefab, _enemyStatusParent).GetComponent<StatusListItem>().Init(status.Key, status.Value.ToString());
        }
        _foundGameData.OnEnd -= ShowEndScreen;
    }
}
