using System.Collections.Generic;
using Core.Observer_Pattern;
using FSM;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using StateMachine = FSM.StateMachine;

namespace Player
{
    public class PJumpState : PUpNDownState
    {
        
        

        public PJumpState(string name, StateMachine stateMachine) : base(name, stateMachine)
        {
            
        }
            
        public override void Enter()
        {
            base.Enter();
            _rigidbody2D.velocity = _rigidbody2D.velocity * 0.0f;
            _rigidbody2D.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);

            _jumpCnt++;
            _pStateMachine.ChangeState(_pStateMachine._pFallState);
            
            _animator.SetBool(b_isJump, true);
        }

        public override void UpdateLogic()
        {
            base.UpdateLogic();
            
            
        }

        public override void UpdatePhysics()
        {
            base.UpdatePhysics();
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}