using FireAndWater.Utils;
using NaughtyAttributes;
using System.Collections.Generic;
using System.Linq;
using _Project.Scripts.UI;
using UnityEngine;

namespace FireAndWater.Entities
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerEntity : Entity, IMoveable
    {
        [Header("Dependencies")] [SerializeField]
        private GroundChecker _groundChecker;

        [SerializeField] private AnimationController _animationController;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private UI _ui;

        [Space(10), Header("Actions")] [SerializeField]
        private List<KeyAction> _actionsKeyPress = new List<KeyAction>();

        [SerializeField] private List<KeyAction> _actionsKeyDown = new List<KeyAction>();
        [SerializeField] private List<KeyAction> _actionsKeyUp = new List<KeyAction>();

        [Space(10), Header("Property")] [Min(0.01f), SerializeField]
        private float _speed = 3;

        [Min(0.01f), SerializeField] private float _jumpHeight = 1;

        private bool _isWallSlidingRight = false;
        private bool _isWallSlidingLeft = false;
        private float _moveModifer = 0;

        private Rigidbody2D _body;

        private void Start()
        {
            _body = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (_ui._inMenu) return;

            _moveModifer = Input.GetAxis("Horizontal");

            Vector3 position = transform.position;
            RaycastHit2D[] hits = new[]
            {
                Physics2D.BoxCast(position, new Vector2(0.95f, 0.9f), 0f, Vector2.right, 0.05f, 1),
                Physics2D.BoxCast(position, new Vector2(0.95f, 0.9f), 0f, Vector2.left, 0.05f, 1),
            };

            if (hits[0].collider != null) _isWallSlidingRight = true;
            else _isWallSlidingRight = false;
            if (hits[1].collider != null) _isWallSlidingLeft = true;
            else _isWallSlidingLeft = false;

            foreach (KeyAction action in _actionsKeyPress.Where(action => Input.GetKey(action.KeyCode)))
            {
                action.Call?.Invoke();
            }

            foreach (KeyAction action in _actionsKeyDown.Where(action => Input.GetKeyDown(action.KeyCode)))
            {
                action.Call?.Invoke();
            }

            foreach (KeyAction action in _actionsKeyUp.Where(action => Input.GetKeyUp(action.KeyCode)))
            {
                action.Call?.Invoke();
            }

            _animationController.SetSpeed(Mathf.Abs(_body.velocity.x));
            LookDirection(_body.velocity.x);
        }

        public void Move(string directionName)
        {
            Vector2 direction = directionName.ToVector2();
            if (direction.x != 0)
            {
                if ((!_isWallSlidingRight && _moveModifer > 0f) || (!_isWallSlidingLeft && _moveModifer < 0f))
                {
                    _body.velocity = new Vector2(direction.x * _speed * Mathf.Abs(_moveModifer), _body.velocity.y);
                }
            }
            else if (direction.y > 0f && _groundChecker.IsGround)
            {
                _body.AddForce(direction * Mathf.Sqrt(_jumpHeight * -2 * Physics2D.gravity.y), ForceMode2D.Impulse);
                _groundChecker.IsGround = false;
            }
        }

        private void LookDirection(float value)
        {
            if (value > 0f)
            {
                _spriteRenderer.flipX = true;
            }
            else if (value < 0f)
            {
                _spriteRenderer.flipX = false;
            }
        }

        protected override void OnEntityEntered2D(Entity entity)
        {
        }
    }
}