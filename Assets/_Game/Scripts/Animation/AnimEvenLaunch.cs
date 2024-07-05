using UnityEngine;
using UnityEngine.Events;

public class AnimEvenLaunch : MonoBehaviour
{
    [SerializeField] private UnityEvent _onAnimEvent = new UnityEvent();

    public void LaunchEvent()
    {
        _onAnimEvent?.Invoke();
    }
}
