using System.Collections.Generic;
using Core.Observer_Pattern;
using FSM;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using StateMachine = FSM.StateMachine;

namespace Player
{
    public class PAllStates : BaseState
    {
        protected PStateMachine _pStateMachine;
        protected AudioSource _audioSource;
        protected Rigidbody2D _rigidbody2D;
        protected Animator _animator;
        protected SpriteRenderer _spriteRenderer;
        protected GameObject _self;
        protected CircleCollider2D _circleCollider2D;

        protected float _horizontalInput; 
        protected float _verticalInput; 
        protected Vector2 _direction = new Vector2(); //the direction character is facing 
        
        
        protected static float _runSpeed = 5.75f; //player's speed when running
        protected static float _speed = _runSpeed; //current player's speed
        protected static float _jumpSpeed = _runSpeed * 4.5f;
        protected static float _tiltSpeed = _runSpeed / 2;

        protected int _jumpCnt = 0;
        protected int _playerId;
        protected GameObject _otherPlayer;
        
        protected MagneticState _magneticStateScript;


        protected string b_isIdle = "isIdle";
        protected string b_isCrouch = "isCrouch";
        protected string b_isJump = "isJump";
        protected string b_isRun = "isRun"; 

        public PAllStates(string name, StateMachine stateMachine) : base(name, stateMachine)
        {
            
        }
            
        public override void Enter()
        {
            base.Enter();
            _pStateMachine = (PStateMachine) stateMachine;

            _audioSource = _pStateMachine._audioSource;
            _rigidbody2D = _pStateMachine._rigidbody2D;
            _animator = _pStateMachine._animator;
            _spriteRenderer = _pStateMachine._spriteRenderer;
            _self = _pStateMachine._self;

            _playerId = _pStateMachine._playerId;
            _otherPlayer = _pStateMachine._otherPlayer;
            _circleCollider2D = _pStateMachine._circleCollider2D;

        }

        public override void UpdateLogic()
        {
            base.UpdateLogic();

            _pStateMachine._isCrouch = false;
            _animator.SetBool(b_isCrouch, false);
            
            
            // if (Input.GetKeyDown(KeyCode.Escape))
            // {
            //     _pStateMachine.NotifyObservers(IEvent.OnGamePause);
            // }

            if (_self.CompareTag("Player1"))
            {
                _horizontalInput = Input.GetAxis("Horizontal1");
                _verticalInput = Input.GetAxis("Vertical1");

                if (_verticalInput < -Mathf.Epsilon)
                {
                    _pStateMachine._isCrouch = true;
                    _animator.SetBool(b_isCrouch, true);
                }
                    

                if (Input.GetKeyDown(KeyCode.R))
                    _pStateMachine._magneticStateScript._magneticState = IMagnetic.Positive;
                else if (Input.GetKeyDown(KeyCode.T))
                    _pStateMachine._magneticStateScript._magneticState = IMagnetic.Negative;
                // else 
                    // _pStateMachine._magneticStateScript._magneticState = IMagnetic.None;
            }
            else if (_self.CompareTag("Player2"))
            {
                _horizontalInput = Input.GetAxis("Horizontal2");
                _verticalInput = Input.GetAxis("Vertical2");

                if (_verticalInput < -Mathf.Epsilon)
                {
                    _pStateMachine._isCrouch = true;
                    _animator.SetBool(b_isCrouch, true);
                }
                    
                
                if (Input.GetKeyDown(KeyCode.Keypad1))
                    _pStateMachine._magneticStateScript._magneticState = IMagnetic.Positive;
                else if (Input.GetKeyDown(KeyCode.Keypad2))
                    _pStateMachine._magneticStateScript._magneticState = IMagnetic.Negative;
                // else 
                //     _pStateMachine._magneticStateScript._magneticState = IMagnetic.None;
            }
            
            
            _direction = new Vector2(_horizontalInput, _verticalInput);
            _direction.Normalize();

            if (_direction.x < -Mathf.Epsilon)
                _self.transform.localScale = new Vector3(-1f, 1f, 1f);
            else if (_direction.x > Mathf.Epsilon)
                _self.transform.localScale = new Vector3(1f, 1f, 1f);

            // Debug.Log(_direction);
        }


    }
}