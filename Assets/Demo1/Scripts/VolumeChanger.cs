using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class VolumeChanger: MonoBehaviour
{
    [SerializeField] private GameObject _point;
    [SerializeField] private Slider _slider;

    private bool _isPlaying;
    private float _maxVolume;
    private int _minVolume;
    private float _duration;

    private void Start()
    {
        _maxVolume = 1f;
        _minVolume = 0;
        _duration = 4f;
    }

    private void Update()
    {
        _isPlaying = _point.GetComponent<PointHouse>().IsAlarmWork();

        if (_isPlaying == true)
        {
            _slider.DOValue(_maxVolume, _duration).SetEase(Ease.Linear);               
        }
        else
        {
            _slider.DOValue(_minVolume, _duration).SetEase(Ease.Linear);
        }
    }
}