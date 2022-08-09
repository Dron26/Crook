using UnityEngine;

public class LightAlarm: MonoBehaviour
{
    [SerializeField] private GameObject _point;

    private Light _light;
    private Vector3 Rotation;
    private Quaternion startRotation;
    private bool _isWork;

    private void Awake()
    {
        _light=GetComponent<Light>();
    }

    private void Start()
    {
        float speedX = 10;
        float speedY = 10;
        Rotation = new Vector3(speedX, 0, speedY);
        startRotation =transform.rotation;
    }

    private void Update()
    {
        _isWork = _point.GetComponent<PointHouse>().IsAlarmWork();

        if (_isWork)
        {
            _light.enabled = _isWork;
            float speed = 13;
            transform.Rotate(Rotation * Time.deltaTime * speed);
        }
        else
        {
            _light.enabled = _isWork;
            transform.rotation = startRotation;
        }
    }
}
