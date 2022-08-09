using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private HashAnimationNames _animBase;
    [SerializeField] private OutsideSide _outsideSide;
    [SerializeField] private InsideSide _insideSide;

    private Animator _animator;
    private bool _isSomeoneComeFromOutside;
    private bool _isSomeoneComeFromIn;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _isSomeoneComeFromOutside = _outsideSide.IsSomeoneComeOutside();
        _isSomeoneComeFromIn = _insideSide.IsSomeoneComeInside();
    }

    private void Update()
    {
        _isSomeoneComeFromOutside = _outsideSide.IsSomeoneComeOutside();
        _isSomeoneComeFromIn = _insideSide.IsSomeoneComeInside();

        if (_isSomeoneComeFromOutside == false & _isSomeoneComeFromIn == false)
        {
            _animator.SetTrigger(_animBase.CloseHash);
            _animator.SetBool(_animBase.OpenInHash, _isSomeoneComeFromOutside);
            _animator.SetBool(_animBase.OpenOutHash, _isSomeoneComeFromIn);
        }
        else if (_isSomeoneComeFromOutside & _isSomeoneComeFromIn==false)
        {
            _animator.ResetTrigger(_animBase.CloseHash);
            _animator.SetBool(_animBase.OpenInHash, _isSomeoneComeFromOutside);
        }
        else if (_isSomeoneComeFromIn & _isSomeoneComeFromOutside == false)
        {
            _animator.ResetTrigger(_animBase.CloseHash);
            _animator.SetBool(_animBase.OpenOutHash, _isSomeoneComeFromIn);
        }            
    }
}
