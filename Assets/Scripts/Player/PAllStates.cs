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
        protected Collider2D _collider2D;
        protected Rigidbody2D _rigidbody2D;
        protected Animator _animator;
        protected SpriteRenderer _spriteRenderer;
        protected GameObject _self;

        protected static float _horizontalInput; 
        protected static float _verticalInput; 
        protected static Vector2 _direction = new Vector2(); //the direction character is facing 
        
        
        protected static float _runSpeed = 5.75f; //player's speed when running
        protected static float _speed = _runSpeed; //current player's speed
        protected static float _jumpSpeed = _runSpeed * 4.5f;
        protected static float _tiltSpeed = _runSpeed / 2;

        protected static int _jumpCnt = 0;
        

        public PAllStates(string name, StateMachine stateMachine) : base(name, stateMachine)
        {
            
        }
            
        public override void Enter()
        {
            base.Enter();
            _pStateMachine = (PStateMachine) stateMachine;

            _audioSource = _pStateMachine._audioSource;
            _collider2D = _pStateMachine._collider2D;
            _rigidbody2D = _pStateMachine._rigidbody2D;
            _animator = _pStateMachine._animator;
            _spriteRenderer = _pStateMachine._spriteRenderer;
            _self = _pStateMachine._self;



        }

        public override void UpdateLogic()
        {
            base.UpdateLogic();

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _pStateMachine.NotifyObservers(IEvent.OnGamePause);
            }
            
    
            _horizontalInput = Input.GetAxis("Horizontal");
            _verticalInput = Input.GetAxis("Vertical");

            _direction = new Vector2(_horizontalInput, _verticalInput);
            _direction.Normalize();
        }


    }
}