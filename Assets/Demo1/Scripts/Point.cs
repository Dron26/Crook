using UnityEngine;

public class Point : MonoBehaviour
{
    private Collider _collider;

    private void Awake()
    {
        _collider=GetComponent<Collider>();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Crook>())
        {          
            _collider.enabled = false;
        }
    }
}
