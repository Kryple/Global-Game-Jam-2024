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

        public AudioSource _audioSource;
        [FormerlySerializedAs("Something")] public Collider2D _collider2D;
        public Rigidbody2D _rigidbody2D;
        public Animator _animator;
        public SpriteRenderer _spriteRenderer;
        public AudioClip _walkingSound;
        public GameObject _self;
        
        

        private void Awake()
        {
            Time.timeScale = 1f;
            TryGetComponent<AudioSource>(out _audioSource);
            TryGetComponent<Collider2D>(out _collider2D);
            TryGetComponent<Rigidbody2D>(out _rigidbody2D);
            TryGetComponent<Animator>(out _animator);
            TryGetComponent<SpriteRenderer>(out _spriteRenderer);
            _self = this.gameObject;
         

            CheckComponentNull(_audioSource);
            CheckComponentNull(_collider2D);
            CheckComponentNull(_rigidbody2D);
            CheckComponentNull(_animator);
            CheckComponentNull(_spriteRenderer);


            _pIdleState = new PIdleState("PIdleState", this);
            _pRunState = new PRunState("PRunState", this);
            _pAllStates = new PAllStates("PAllStates", this);

            
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
        
        
        
        



    }
}
