using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private AnimationCurve _animCurve = new AnimationCurve();
    [SerializeField] private CameraShakeSignalSO _shakeSignalSO; 
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private float _shakeTime = 0.2f;
    private Coroutine _coroutine;
    private Vector3 _initialPosition = Vector3.zero;

    private void Start()
    {
        _initialPosition = transform.position;
    }

    private void OnEnable()
    {
        _shakeSignalSO.onCameraShake += MakeShake;
    }

    private void OnDisable()
    {
        _shakeSignalSO.onCameraShake -= MakeShake;
    }

    private void MakeShake()
    {
        if (_coroutine != null) 
        { 
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(Shake());
    }

    private IEnumerator Shake()
    {
        float currentTime = 0.0f;

        while (currentTime < _shakeTime)
        {
            yield return null;
            currentTime += Time.deltaTime;
            transform.position = _initialPosition + Vector3.right * _animCurve.Evaluate(currentTime/_shakeTime);
        }

        transform.position = _initialPosition;
        _coroutine = null;
    }
}
