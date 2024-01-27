using System.Collections.Generic;
using FSM;
using UnityEngine;

namespace Player
{
    public class PPatrolState : PAllStates
    {
        
        
        
        
        public PPatrolState(string name, StateMachine stateMachine) : base(name, stateMachine)
        {
            
        }

        public override void Enter()
        {
            base.Enter();
        }

        public override void UpdateLogic()
        {
            base.UpdateLogic();
            
            if (_pStateMachine.CurrentState() != _pStateMachine._pJumpState)
            {
                if (_verticalInput > Mathf.Epsilon && _jumpCnt == 0)
                {
                    _pStateMachine.ChangeState(_pStateMachine._pJumpState);
                }
            }
            
            
        }
    }
}