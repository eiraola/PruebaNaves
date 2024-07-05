using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class BoostSkill : MonoBehaviour, IStopable, IReseteable
{
    [Tooltip("The amount of speed gained with the boost")]
    [SerializeField] private float _gainedSpeed = 1f;
    [Tooltip("How long is going to stand the boost in its apex")]
    [SerializeField] private float _boostDuration = 1f;
    [Tooltip("How long it will take to go back to normal speed after the boost")]
    [SerializeField] private float _boostReductionTime = 1f;
    [Tooltip("The time needed to use the boost again")]
    [SerializeField] private float _recoverTime = 1f;
    [SerializeField] private BoostSignalSO _boostSignalSO;
    [SerializeField] private SoundSignalSO _soundSignalSO;
    [SerializeField] private UnityEvent _onBoostEvent = new UnityEvent();
    private bool _boostAvailable = true;
    private float _currentBoostValue = 0f;
    private Coroutine _boostCoroutine;
    private Coroutine _recoverCoroutine;

    public float CurrentBoostValue { get => _currentBoostValue;}

    public void Boost()
    {
        if (!_boostAvailable)
        {
            return;
        }

        InterruptCorroutine(_boostCoroutine);
        BoostSound();
        _boostAvailable = false;
        _currentBoostValue = _gainedSpeed;
        _boostCoroutine = StartCoroutine(CoKeepMaxBoostSpeed());
        _recoverCoroutine = StartCoroutine(CoBoostRecover());

    }

    private void InterruptCorroutine(Coroutine coroutine)
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
        }
    }

    public void Restart()
    {
        _boostSignalSO.AccelrationCDValueChanged(1.0f);
        _boostAvailable = true;
    }

    public void Stop()
    {
        InterruptCorroutine(_boostCoroutine);
        InterruptCorroutine(_recoverCoroutine);
        _currentBoostValue = 0.0f;
    }

    private void BoostSound()
    {
        if (!_soundSignalSO)
        {
            return;
        }
        _soundSignalSO.PlayClipSound(EClip.Boost);
    }
    #region Coroutines

    private IEnumerator CoKeepMaxBoostSpeed()
    {
        yield return new WaitForSeconds(_boostDuration);

        _boostCoroutine = StartCoroutine(CoLoseBoostSpeed());
    }

    private IEnumerator CoLoseBoostSpeed()
    {
        float currentTime = _boostReductionTime;

        while (currentTime > 0.0f) {
            yield return null;

            currentTime -= Time.deltaTime;
            _currentBoostValue = _gainedSpeed * (currentTime / _boostDuration);
        }

        _currentBoostValue = 0.0f;
        _boostCoroutine = null;
    }

    private IEnumerator CoBoostRecover()
    {
        float currentTime = _recoverTime;

        while (currentTime > 0.0f)
        {
            yield return null;

            currentTime -= Time.deltaTime;
            _boostSignalSO.AccelrationCDValueChanged(1 - (currentTime / _recoverTime));
        }

        _recoverCoroutine = null;
        _boostAvailable = true;
    }

    #endregion
}
