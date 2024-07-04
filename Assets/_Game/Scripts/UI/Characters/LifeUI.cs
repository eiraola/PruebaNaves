using UnityEngine;
using UnityEngine.UI;

public class LifeUI : MonoBehaviour
{
    [SerializeField] private Image _lifeBar;
    [SerializeField] private Image _postLifebar;
    [SerializeField] private float _postLifeBarUpdateSpeed = 10;
    [SerializeField] private LifeSystemSignalSO _lifeSystemSignalSO;
    private float _currentPercent = 0.0f;
    void OnEnable()
    {
        _lifeSystemSignalSO.onLifeChanged += UpdateBar;
    }

    void OnDisable()
    {
        _lifeSystemSignalSO.onLifeChanged -= UpdateBar;
    }

    private void Update()
    {
        UpdatePostLifeBar(Time.deltaTime);
    }

    private void UpdatePostLifeBar(float deltaTime)
    {
        _postLifebar.fillAmount += (_currentPercent - _postLifebar.fillAmount) * 0.1f * _postLifeBarUpdateSpeed * deltaTime;  
    }

    private void UpdateBar(float lifePercent)
    {
        _currentPercent = lifePercent;
        _lifeBar.fillAmount = lifePercent;
    }
}
