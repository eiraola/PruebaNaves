using UnityEngine;
using UnityEngine.UI;

public class LifeUI : MonoBehaviour
{
    [SerializeField] private Image _lifeBar;
    [SerializeField] private LifeSystemSignalSO _lifeSystemSignalSO;
    void OnEnable()
    {
        _lifeSystemSignalSO.onLifeChanged += UpdateBar;
    }

    void OnDisable()
    {
        _lifeSystemSignalSO.onLifeChanged -= UpdateBar;
    }

    private void UpdateBar(float lifePercent)
    {
        _lifeBar.fillAmount = lifePercent;
    }
}
