using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointHouse : MonoBehaviour
{    
    private bool _isAlarmWork;

    private void Start()
    {
        _isAlarmWork = false;
    }

    private void OnTriggerEnter(Collider other)
    {     
        if (other.GetComponent<Crook>())
        {
            _isAlarmWork = true;
        }  
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Crook>())
       {
            StartCoroutine(RotationLight());          
       }
    }
    public bool IsAlarmWork()
    {
        return _isAlarmWork;
    }

    IEnumerator RotationLight()
    {
        int _workTimeAlarm = 5;     
        yield return new WaitForSeconds(_workTimeAlarm);
        _isAlarmWork = false;
    }
}
