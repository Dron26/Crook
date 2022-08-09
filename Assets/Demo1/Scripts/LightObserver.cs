using UnityEngine;

public class LightObserver: MonoBehaviour
{
    [SerializeField] private GameObject _point;

    private Light _light;
    private GameObject _target;
    private Quaternion _rotation;
    private bool _isWork;

    private void Awake()
    {
        _light = GetComponent<Light>();
    }

    private void Start()
    {
        _light.enabled = false;
        _rotation =transform.rotation;
    }

    private void Update()
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
