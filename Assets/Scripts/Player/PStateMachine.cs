using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Core.Observer_Pattern;
using FSM;
using UnityEngine.Serialization;

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
        [FormerlySerializedAs("Something")] public Collider2D _collider2D;
        public Rigidbody2D _rigidbody2D;
        public Animator _animator;
        public SpriteRenderer _spriteRenderer;
        public AudioClip _walkingSound;
        public GameObject _self;

        public int _playerId;
        public GameObject _otherPlayer;
        
        public MagneticState _magneticStateScript;

        public float _forcePower = 12f;

        private void Awake()
        {
            Time.timeScale = 1f;
            TryGetComponent<AudioSource>(out _audioSource);
            TryGetComponent<Collider2D>(out _collider2D);
            TryGetComponent<Rigidbody2D>(out _rigidbody2D);
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
         

            CheckComponentNull(_audioSource);
            CheckComponentNull(_collider2D);
            CheckComponentNull(_rigidbody2D);
            CheckComponentNull(_animator);
            CheckComponentNull(_spriteRenderer);


            _pIdleState = new PIdleState("PIdleState", this);
            _pRunState = new PRunState("PRunState", this);
            _pAllStates = new PAllStates("PAllStates", this);
            _pJumpState = new PJumpState("PJumpState", this);
            _pFallState = new PFallState("PFallState", this);


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

        public void OnNotify(IEvent @event)
        {
            
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            Debug.Log("whut");
            if (other.CompareTag("Player1") || other.CompareTag("Player2"))
            {
                if ((other.transform.GetComponent<MagneticState>()._magneticState == IMagnetic.None)
                    || (_magneticStateScript._magneticState == IMagnetic.None))
                {
                    
                }
                else if (other.GetComponent<MagneticState>()._magneticState != _magneticStateScript._magneticState)
                {
                    Vector2 forceDirection = other.transform.position - _self.transform.position;
                
                    _rigidbody2D.AddForce(forceDirection * _forcePower);
                }
                else if (other.GetComponent<MagneticState>()._magneticState == _magneticStateScript._magneticState)
                {
                    Vector2 forceDirection = _self.transform.position - other.transform.position  ;
                
                    _rigidbody2D.AddForce(forceDirection * _forcePower);
                }
            }
        }
    }
}
