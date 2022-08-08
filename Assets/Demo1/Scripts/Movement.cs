using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Transform _path;

    private float _speed;
    private Transform[] _points;
    private int _currentPoint;
    private bool _isPointReached;
    private bool _isEndPointReached;
    private float _timeWaiting;
    private bool _isHousePointReached;

    void Start()
    {
        _speed = 1F;
        _isEndPointReached = false;
        _points = new Transform[_path.childCount];
        _timeWaiting = 5f;

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);
        }
    }

    void Update()
    {
        if (_isPointReached== false & _isEndPointReached == false)
        {
            Transform target = _points[_currentPoint];
            transform.LookAt(target.transform);
            transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
        }
    }

    public bool IsPointReached()
    {
        return _isPointReached;
    }

    public bool IsPointEndReached()
    {
        return _isEndPointReached;
    }

    public bool IsHousePointReached()
    {
        return _isHousePointReached;
    }

    IEnumerator PointReached()
    {    
        yield return  new WaitForSeconds(_timeWaiting);
        _isPointReached = false;
        _currentPoint++;
    }

    IEnumerator HousePointReached()
    {
        yield return new WaitForSeconds(_timeWaiting);
        _isHousePointReached = true;
        _currentPoint++;
        transform.Rotate(0, 180, 0);
    }

     private void OnTriggerEnter(Collider other)
    {       
        Transform target = _points[_currentPoint];

        if (other.GetComponent<Point>())
        {
            _isPointReached = true;
            StartCoroutine(PointReached());
        }
        else if (other.GetComponent<PointHouse>())
        {
            _isPointReached = true;
            StartCoroutine(HousePointReached());
        }
        else if (other.GetComponent<EndPoint>())
        {
            _isEndPointReached = true;
            transform.Rotate(0, 180, 0);
        }     
    }
}
