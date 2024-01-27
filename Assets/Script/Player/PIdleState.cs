using FSM;
using UnityEngine;

namespace Player
{
    public class PIdleState : PPatrolState
    {
        // protected PStateMachine _pStateMachine;
        
        public PIdleState(string name, StateMachine stateMachine) : base(name, stateMachine)
        {
            // _pStateMachine = (PStateMachine) stateMachine;
            
        }
        
        public override void Enter()
        {
            base.Enter();
            _jumpCnt = 0;
            
            //Slow the player down instead of stop immediately
            _rigidbody2D.velocity = _rigidbody2D.velocity * 0.0f;
            _animator.SetBool(b_isIdle, true);
            
            // Debug.Log("pre x: " + _prevDir.x + ", prev y: " + _prevDir.y);
            
        }

        public override void UpdateLogic()
        {
            base.UpdateLogic();
            if (Mathf.Abs(_horizontalInput) > Mathf.Epsilon)
            {
                _pStateMachine.ChangeState(_pStateMachine._pRunState);
            }
            
        }

        public override void UpdatePhysics()
        {
            base.UpdatePhysics();
        }
    }
}