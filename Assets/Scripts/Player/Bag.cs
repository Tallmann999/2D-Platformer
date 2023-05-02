using TMPro;
using UnityEngine;

public class Bag : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinCountView;

    private int _cointCount;

    private void Update()
    {
        _coinCountView.text = _cointCount.ToString();
    }

    public void AddCoin()
    {
        _cointCount++;
    }
}
