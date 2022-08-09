using UnityEngine;

public class InsideSide : MonoBehaviour
{
    private bool _isSomeoneComeUp;

    public bool IsSomeoneComeInside()
    {
        return _isSomeoneComeUp;
    }

    private void Start()
    {
        _isSomeoneComeUp = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Crook>())
        {
            _isSomeoneComeUp = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Crook>())
        {
            _isSomeoneComeUp = false;
        }
    }
}
