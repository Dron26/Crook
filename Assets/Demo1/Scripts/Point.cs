using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Point : MonoBehaviour
{
    [SerializeField] Collider collider;

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Crook>())
        {
            collider.enabled = false;
        }
    }
}
