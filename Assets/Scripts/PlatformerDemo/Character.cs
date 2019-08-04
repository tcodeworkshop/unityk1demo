using System.Collections;
using UnityEngine;

namespace Assets.Scripts.PlatformerDemo
{
    public abstract class Character : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _spriteRenderer = null;

        [SerializeField]
        private Animator _animator = null;

        [SerializeField]
        private Rigidbody2D _rigidbody = null;

        [SerializeField]
        private float _speed = 1;

        [SerializeField]
        private float _jumpForce = 5;

        [SerializeField]
        private string _opponentTag = "Player";

        private CharacterAnimation _animation;

        private int _jumpCounter;
        private bool _isPlayingAttack;

        private bool _isDead;

        protected SpriteRenderer spriteRenderer
        {
            get { return _spriteRenderer; }
        }

        protected new Rigidbody2D rigidbody
        {
            get { return _rigidbody; }
        }

        public void Awake()
        {
            _animation = new CharacterAnimation(_animator);
            _jumpCounter = 2;
            _isPlayingAttack = false;
            _isDead = false;
        }

        public void Update()
        {
            if (_isDead)
            {
                setWalkingVelocity(WalkDirection.None);
                return;
            }

            onUpdate();
        }

        protected virtual void onUpdate()
        {
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (_isDead) return;

            if (collision.gameObject.CompareTag("Ground"))
            {
                if (_rigidbody.velocity.y <= 0)
                {
                    resetJumpCounter();
                    _animation.SetInAir(false);
                }
            }
        }

        public void OnTriggerExit2D(Collider2D collision)
        {
            if (_isDead) return;

            if (collision.gameObject.CompareTag("Ground"))
            {
                _animation.SetInAir(true);
            }
        }

        protected void walk(WalkDirection direction)
        {
            if (canWalk())
            {
                setWalkingVelocity(direction);

                switch (direction)
                {
                    case WalkDirection.None:
                        _animation.SetWalking(false);
                        break;

                    case WalkDirection.Left:
                    case WalkDirection.Right:
                        _animation.SetWalking(true);
                        break;
                }

                setFlipped(direction);
            }
            else
            {
                setWalkingVelocity(WalkDirection.None);
            }
        }

        private bool canWalk()
        {
            return _isPlayingAttack == false;
        }

        private void setWalkingVelocity(WalkDirection direction)
        {
            float speedMultiplier = 0;
            switch (direction)
            {
                case WalkDirection.Left:
                    speedMultiplier = -1;
                    break;

                case WalkDirection.Right:
                    speedMultiplier = 1;
                    break;
            }

            var velocity = _rigidbody.velocity;
            velocity.x = speedMultiplier * _speed;
            _rigidbody.velocity = velocity;
        }

        private void setFlipped(WalkDirection direction)
        {
            switch (direction)
            {
                case WalkDirection.Left:
                    _spriteRenderer.flipX = true;
                    break;

                case WalkDirection.Right:
                    _spriteRenderer.flipX = false;
                    break;
            }
        }

        protected void jump()
        {
            if (canJump())
            {
                resetJumpVelocity();
                addJumpForce();
                decrementJumpCounter();
            }
        }

        private bool canJump()
        {
            return _jumpCounter > 0
                && _isPlayingAttack == false;
        }

        protected void resetJumpVelocity()
        {
            Vector2 velocity = _rigidbody.velocity;
            velocity.y = 0;
            _rigidbody.velocity = velocity;
        }

        protected void addJumpForce()
        {
            _rigidbody.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
        }

        private void decrementJumpCounter()
        {
            --_jumpCounter;
        }

        private void resetJumpCounter()
        {
            _jumpCounter = 2;
        }

        protected void attack()
        {
            _animation.Attack();

            detectOpponentAndAttack();
        }

        private void detectOpponentAndAttack()
        {
            Vector2 origin = transform.position;
            origin.y += 0.5f;

            Vector2 direction;
            if (spriteRenderer.flipX)
                direction = Vector2.left;
            else
                direction = Vector2.right;

            var hits = Physics2D.RaycastAll(origin, direction, 1);

            for (int i = 0, c = hits.Length; i < c; ++i)
            {
                var hit = hits[i];
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.CompareTag(_opponentTag))
                    {
                        hit.collider.gameObject.GetComponent<Character>().Die();
                    }
                }
            }
        }

        public void Unity_AttackAnimationBegan()
        {
            _isPlayingAttack = true;
        }

        public void Unity_AttackAnimationEnded()
        {
            _isPlayingAttack = false;
        }

        public void Die()
        {
            if (_isDead) return;

            _isDead = true;

            deactiveColliders();

            StartCoroutine(playDying());
        }

        private void deactiveColliders()
        {
            var colliders = GetComponentsInChildren<Collider2D>();
            for (int i = 0, c = colliders.Length; i < c; ++i)
            {
                colliders[i].enabled = false;
            }
        }

        protected abstract IEnumerator playDying();
    }
}