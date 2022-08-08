using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private OutsideSide _outsideSide;
    [SerializeField] private InsideSide _insideSide;

    private Animator _animator;
    private bool _isSomeoneComeFromOutside;
    private bool _isSomeoneComeFromIn;

    private void Start()
    {
        _animator=GetComponent<Animator>();
    }

    void Update()
    {
        _isSomeoneComeFromOutside = _outsideSide.IsSomeoneComeOutside();
        _isSomeoneComeFromIn = _insideSide.IsSomeoneComeInside();

        if (_isSomeoneComeFromOutside == false & _isSomeoneComeFromIn == false)
        {
            _animator.SetTrigger("Close");
            _animator.SetBool("IsOpenIn", _isSomeoneComeFromOutside);
            _animator.SetBool("IsOpenOut", _isSomeoneComeFromIn);
        }
        else if (_isSomeoneComeFromOutside & _isSomeoneComeFromIn==false)
        {
            _animator.ResetTrigger("Close");
            _animator.SetBool("IsOpenIn", _isSomeoneComeFromOutside);
        }
        else if (_isSomeoneComeFromIn & _isSomeoneComeFromOutside == false)
        {
            _animator.ResetTrigger("Close");
            _animator.SetBool("IsOpenOut", _isSomeoneComeFromIn);
        }            
    }
}
