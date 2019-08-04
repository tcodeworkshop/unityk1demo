using UnityEngine;

namespace Assets.Scripts.PlatformerDemo
{
    public class CharacterAnimation
    {
        private readonly Animator _animator;

        private readonly int _idIsWalking;
        private readonly int _idIsInAir;
        private readonly int _idAttack;

        public CharacterAnimation(Animator animator)
        {
            _animator = animator;

            _idIsWalking = Animator.StringToHash("IsWalking");
            _idIsInAir = Animator.StringToHash("IsInAir");
            _idAttack = Animator.StringToHash("Attack");
        }

        public void SetWalking(bool isWalking)
        {
            _animator.SetBool(_idIsWalking, isWalking);
        }

        public void SetInAir(bool isInAir)
        {
            _animator.SetBool(_idIsInAir, isInAir);
        }

        public void Attack()
        {
            _animator.SetTrigger(_idAttack);
        }
    }
}