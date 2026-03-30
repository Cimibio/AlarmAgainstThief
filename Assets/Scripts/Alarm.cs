using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AlarmDetector _alarmDetector;

    [SerializeField] private float _maxVolume = 1.0f;
    [SerializeField] private float _fadeTime = 3.0f;

    private float _targetVolume = 0f;
    private bool _isThiefInside = false;

    private void OnEnable()
    {
        _alarmDetector.ThiefEntered += EnableAlarm;
        _alarmDetector.ThiefExited += DisableAlarm;
    }

    private void Update()
    {
        
    }

    private void OnDisable()
    {
        _alarmDetector.ThiefEntered -= EnableAlarm;
        _alarmDetector.ThiefExited -= DisableAlarm;
    }

    private void EnableAlarm()
    {

    }

    private void DisableAlarm()
    {

    }
}
