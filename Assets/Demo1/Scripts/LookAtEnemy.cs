using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _point;
    [SerializeField] private Light _light;

    private GameObject _target;
    private Quaternion _rotation;
    bool _isWork;

    void Start()
    {
        _light.enabled = false;
        _rotation =transform.rotation;
    }

    void Update()
    {
        _isWork = _point.GetComponent<PointHouse>().IsAlarmWork();

        if (_isWork)
        {
            if (_target!=null)
            {
                transform.LookAt(_target.transform);
            }
        }
        else
        {
            transform.rotation = _rotation;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Crook>()& _isWork==true)
        {
            _light.enabled = true;
            _target = other.gameObject;           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Crook>())
        {
            _target = null;
            _light.enabled = false;
            transform.rotation= _rotation;
        }
    }
}
