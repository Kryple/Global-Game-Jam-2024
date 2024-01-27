using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Core.Observer_Pattern;
using FSM;
using Unity.VisualScripting;
using UnityEngine.Serialization;
using StateMachine = FSM.StateMachine;

namespace Player
{
    //Extend IObserver to become an Observer
    
    /*
     Observers list that observing the PStateMachine:
     - InGameUIController
     - 
     */
    public class PStateMachine : StateMachine, IObserver
    {

        [HideInInspector] public PIdleState _pIdleState;
        [HideInInspector] public PRunState _pRunState;
         [HideInInspector] public PAllStates _pAllStates;
         [HideInInspector] public PJumpState _pJumpState;
         [HideInInspector] public PFallState _pFallState;

        public AudioSource _audioSource;
        
        public Rigidbody2D _rigidbody2D;
        public Animator _animator;
        public SpriteRenderer _spriteRenderer;
        public AudioClip _walkingSound;
        public GameObject _self;
        public CircleCollider2D _circleCollider2D;

        public int _playerId;
        public GameObject _otherPlayer;
        
        public MagneticState _magneticStateScript;

        private float _forcePower = 240f;
        public float _ratioForcePower;
        public bool _isCrouch;

        private void Awake()
        {
            Time.timeScale = 1f;
            _audioSource = GetComponent<AudioSource>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            
            
            TryGetComponent<Animator>(out _animator);
            TryGetComponent<SpriteRenderer>(out _spriteRenderer);
            _self = this.gameObject;
            
            
            if (this.CompareTag("Player1"))
            {
                _otherPlayer = GameObject.FindWithTag("Player2");
            }
            else if (this.CompareTag("Player2"))
            {
                _otherPlayer = GameObject.FindWithTag("Player1");
            }

            _magneticStateScript = GetComponent<MagneticState>();
            _circleCollider2D = GetComponent<CircleCollider2D>();

            
            
            
            CheckComponentNull(_animator);
            CheckComponentNull(_spriteRenderer);


            _pIdleState = new PIdleState("PIdleState", this);
            _pRunState = new PRunState("PRunState", this);
            _pAllStates = new PAllStates("PAllStates", this);
            _pJumpState = new PJumpState("PJumpState", this);
            _pFallState = new PFallState("PFallState", this);


        }

        new void Update()
        {
            base.Update();
            if (DistanceToOtherPlayer() <= _circleCollider2D.radius)
                CheckPushAndPull();
        }
        
        public void CheckComponentNull(Component component)
        {
            if (component == null)
            {
                Debug.Log(component.name + component);
            }
        }


        protected override BaseState GetInitialState()
        {
            return _pIdleState;
        }

        public void ChangeToIdle()
        {
            ChangeState(_pIdleState);
        }

        public float DistanceToOtherPlayer()
        {
            float dis = Vector2.Distance(_otherPlayer.transform.position, _self.transform.position);
            return dis;
        }

        public void OnNotify(IEvent @event)
        {
            
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            
            
        }

        private void CheckPushAndPull()
        {
            float distance = DistanceToOtherPlayer();
            
            if ((_otherPlayer.transform.GetComponent<MagneticState>()._magneticState == IMagnetic.None)
                || (_magneticStateScript._magneticState == IMagnetic.None))
            {
                    
            }
            else if (_otherPlayer.GetComponent<MagneticState>()._magneticState != _magneticStateScript._magneticState)
            {

                if (_isCrouch == false)
                {
                    Vector2 forceDirection = (_otherPlayer.transform.position - _self.transform.position);
                    forceDirection.Normalize();
                    _ratioForcePower = distance / _circleCollider2D.radius;
                    Mathf.Clamp(_ratioForcePower, 0.5f, 1f);
                
                    _rigidbody2D.AddForce(forceDirection * _forcePower * _ratioForcePower);    
                }
                
            }
            else if (_otherPlayer.GetComponent<MagneticState>()._magneticState == _magneticStateScript._magneticState)
            {
                if (_isCrouch == false)
                {
                    Vector2 forceDirection = _self.transform.position - _otherPlayer.transform.position  ;
                    forceDirection.Normalize();

                    _ratioForcePower = distance / _circleCollider2D.radius;
                    Mathf.Clamp(_ratioForcePower, 0.5f, 1f);
                    _rigidbody2D.AddForce(forceDirection * _forcePower * _ratioForcePower);
                }
            }
        }
    }
}
