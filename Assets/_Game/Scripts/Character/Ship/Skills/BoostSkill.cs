using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostSkill : MonoBehaviour
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
    private bool _boostAvailable = true;
    private Coroutine _boostCoroutine;
    private Coroutine _recoverCoroutine;

    public void Boost()
    {
        if (!_boostAvailable)
        {
            return;
        }

        _boostAvailable = false;
        _boostSignalSO.SetBoostValue(_gainedSpeed);
        _boostCoroutine = StartCoroutine(CoKeepMaxBoostSpeed());
        _recoverCoroutine = StartCoroutine(CoBoostRecover());

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
            _boostSignalSO.SetBoostValue(_gainedSpeed * (currentTime / _boostDuration));
        }

        _boostSignalSO.SetBoostValue(0.0f);
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

        _boostAvailable = true;
    }

    #endregion
}
