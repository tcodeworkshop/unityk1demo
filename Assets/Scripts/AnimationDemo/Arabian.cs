using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.AnimationDemo
{
    public class Arabian : MonoBehaviour
    {
        private const string WalkingParamName = "IsWalking";
        private const string AttackParamName = "Attack";

        private Animator _animator;
        private int _walkingParamId;
        private int _attackParamId;

        private bool _isAttacking = false;

        public void Awake()
        {
            _animator = GetComponent<Animator>();
            _walkingParamId = Animator.StringToHash(WalkingParamName);
            _attackParamId = Animator.StringToHash(AttackParamName);
        }

        public void Update()
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                _animator.SetBool(_walkingParamId, true);
            }
            else
            {
                _animator.SetBool(_walkingParamId, false);
            }

            if (Input.GetKeyDown(KeyCode.Space) && !_isAttacking)
            {
                _animator.SetTrigger(_attackParamId);
            }
        }

        public void Unity_AttackBegin()
        {
            _isAttacking = true;
        }

        public void Unity_AttackEnd()
        {
            _isAttacking = false;
        }
    }
}
