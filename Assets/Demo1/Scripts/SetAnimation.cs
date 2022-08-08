using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimation : MonoBehaviour
{
    [SerializeField] private Movement _movement;

    private Animator _animator;
    private bool _isWalk;
    private bool _isRun;
    private bool _isEndPoinReach;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        _isWalk = !_movement.IsPointReached();
        _isEndPoinReach=_movement.IsPointEndReached();
        _isRun = _movement.IsHousePointReached();

        _animator.SetBool("isWalk", _isWalk);

        if (_isWalk==false& _isRun == true)
        {
            _animator.SetBool("isRun", _isRun);
        }

        if (_isEndPoinReach==true)
        {
            _animator.SetBool("isRun", false);
        }
    }
}
