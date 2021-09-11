using TMPro;
using UnityEngine;

public class StatusListItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI name, value;

    public void Init(string name, string value)
    {
        this.name.text = name;
        this.value.text = value;
    }
}
