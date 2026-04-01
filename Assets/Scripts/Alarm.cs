using UnityEngine;
using System.Collections;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _maxVolume = 1.0f;
    [SerializeField] private float _fadeTime = 3.0f;

    private AlarmDetector _alarmDetector;
    private Coroutine _changeVolume;

    private void Awake()
    {
        if (TryGetComponent(out AlarmDetector alarmDetector))
            _alarmDetector = alarmDetector;
    }

    private void OnEnable()
    {
        _alarmDetector.ThiefEntered += StartAlarm;
        _alarmDetector.ThiefExited += StopAlarm;
    }

    private void OnDisable()
    {
        _alarmDetector.ThiefEntered -= StartAlarm;
        _alarmDetector.ThiefExited -= StopAlarm;
    }

    private void StartAlarm()
    {
        if (_audioSource.isPlaying == false)
            _audioSource.Play();

        ResetCoroutine(_maxVolume);
    }

    private void StopAlarm()
    {
        ResetCoroutine(0f);
    }

    private void ResetCoroutine(float target)
    {
        if (_changeVolume != null)
            StopCoroutine(_changeVolume);

        _changeVolume = StartCoroutine(ChangeVolume(target));
    }

    private IEnumerator ChangeVolume(float target)
    {
        while (Mathf.Approximately(_audioSource.volume, target) == false)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, target, 1 / _fadeTime * Time.deltaTime);
            yield return null;
        }

        if (target == 0)
            _audioSource.Stop();
    }
}
