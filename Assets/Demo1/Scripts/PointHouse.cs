using System.Collections;
using UnityEngine;

public class PointHouse : MonoBehaviour
{    
    private bool _isAlarmWork;

    public bool IsAlarmWork()
    {
        return _isAlarmWork;
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
            StartCoroutine(RotateLight());          
       }
    }

    private IEnumerator RotateLight()
    {
        int _workTimeAlarm = 5;     
        yield return new WaitForSeconds(_workTimeAlarm);
        _isAlarmWork = false;
    }
}
