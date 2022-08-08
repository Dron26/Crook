using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmLight : MonoBehaviour
{
    [SerializeField] private GameObject _point;
    [SerializeField] private Light _light;

    private Vector3 Rotation;
    private float _speed;
    private Quaternion startRotation;
    private bool _isWork;

    void Start()
    {       
        Rotation = new Vector3(10, 0, 10);
        startRotation =transform.rotation;
    }

     void Update()
    {
        _isWork = _point.GetComponent<PointHouse>().IsAlarmWork();
        _light.enabled = _isWork;

        if (_isWork)
        {
            StartCoroutine(RotationLight()); 
        }
        else
        {
          StopCoroutine(RotationLight());
          transform.rotation = startRotation;
        }
    }

    IEnumerator RotationLight()
    {
        _speed = 13;
        transform.Rotate(Rotation * Time.deltaTime * _speed);
        yield return null;
    }
}
