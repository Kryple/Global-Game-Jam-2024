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
            //Slow the player down instead of stop immediately
            _rigidbody2D.velocity = _rigidbody2D.velocity * 0.0f;
            
            
            // Debug.Log("pre x: " + _prevDir.x + ", prev y: " + _prevDir.y);
            
        }

        public override void UpdateLogic()
        {
            base.UpdateLogic();
            
            
        }

        public override void UpdatePhysics()
        {
            base.UpdatePhysics();
        }
    }
}