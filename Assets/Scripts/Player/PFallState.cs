using System.Collections.Generic;
using Core.Observer_Pattern;
using FSM;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using StateMachine = FSM.StateMachine;


namespace Player
{
    public class PFallState : PUpNDownState
    {
        public PFallState(string name, StateMachine stateMachine) : base(name, stateMachine)
        {
            
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void UpdateLogic()
        {
            base.UpdateLogic();
            
            _self.transform.Translate(new Vector2(_horizontalInput, 0f) * _tiltSpeed * Time.deltaTime);
        }

        public override void UpdatePhysics()
        {
            base.UpdatePhysics();
            if (Mathf.Abs(_rigidbody2D.velocity.y) < Mathf.Epsilon)
            {
                _pStateMachine.ChangeState(_pStateMachine._pIdleState);
            }
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}