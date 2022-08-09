using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorCrook: MonoBehaviour
{
    [SerializeField] private HashAnimationNames _animBase;

    private Movement _movement;
    private Animator _animator;
    private bool _isWalk;
    private bool _isRun;
    private bool _isEndPoinReach;

    private void Awake()
    {
        _movement=GetComponent<Movement>();
        _animator = GetComponent<Animator>();
        _isWalk = true;
    }

    private void Update()
    {
        _isWalk = !_movement.IsPointReached();
        _isEndPoinReach = _movement.IsPointEndReached();
        _isRun = _movement.IsHousePointReached();

        _animator.SetBool(_animBase.WalkHash, _isWalk);

        if (_isWalk==false& _isRun == true)
        {
            _animator.SetBool(_animBase.RunHash, _isRun);
        }

        if (_isEndPoinReach==true)
        {
            _animator.SetBool(_animBase.RunHash, false);
        }
    }
}
