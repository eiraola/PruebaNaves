using UnityEngine;
using UnityEngine.UI;

public class BoostUI : MonoBehaviour
{
    [SerializeField] private Image _boostImage;
    [SerializeField] private BoostSignalSO _boostSignalSO;

    private void OnEnable()
    {
        _boostSignalSO.onAccelerationCDValueChanged += UpdateBoostUI;
    }

    private void OnDisable()
    {
        _boostSignalSO.onAccelerationCDValueChanged -= UpdateBoostUI;
    }

    private void UpdateBoostUI(float newValue)
    {
        _boostImage.fillAmount = newValue;
    }
}
