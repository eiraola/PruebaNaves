using UnityEngine;

public class Wind : MonoBehaviour, IStopable, IReseteable, IInitializable
{
    [SerializeField] private WindDirectionSignalSenderSO _windDirectionSignalSender;
    [SerializeField] private float _windChangeRatio = 10.0f;
    private EWindDirection _currentWindDirection = EWindDirection.Up;
    private float _timeFromLastWindChange = 0;


    private void Update()
    {
        CheckWindChangeTime();
    }

    private void CheckWindChangeTime()
    {
        _timeFromLastWindChange += Time.deltaTime;

        if (_timeFromLastWindChange > _windChangeRatio)
        {
            _timeFromLastWindChange = 0.0f;
            ChangeWindDirection();
        }
    }

    public void ChangeWindDirection()
    {
        float windChange = Random.Range(0.0f, 1.0f);

        if (windChange < 0.25f)
        {
            _currentWindDirection = EWindDirection.Up;
        }
        else if (windChange < 0.5) 
        {
            _currentWindDirection = EWindDirection.Right;
        }
        else if (windChange < 0.75)
        {
            _currentWindDirection = EWindDirection.Left;
        }
        else 
        {
            _currentWindDirection = EWindDirection.Down;
        }
        _windDirectionSignalSender.ChangeWind(_currentWindDirection);
    }

    public void Stop()
    {
        this.enabled = false;
    }

    public void Restart()
    {
        _currentWindDirection = EWindDirection.Up;
        _timeFromLastWindChange = 0;
    }

    public void Initialize()
    {
        this.enabled = true;
    }
}
