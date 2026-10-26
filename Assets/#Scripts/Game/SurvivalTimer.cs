using UnityEngine;
using UnityEngine.UI;

public class SurvivalTimer : MonoBehaviour
{
    [SerializeField] private Text label;

    private float elapsed;

    private void Update()
    {
        elapsed += Time.deltaTime;
        label.text = $"Time: {elapsed:F1}s";
    }
}
