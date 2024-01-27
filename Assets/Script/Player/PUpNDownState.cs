using System.Collections.Generic;
using Core.Observer_Pattern;
using FSM;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using StateMachine = FSM.StateMachine;


namespace Player
{
    public class PUpNDownState : PAllStates
    {
        
        
        
        public PUpNDownState(string name, StateMachine stateMachine) : base(name, stateMachine)
        {
            
        }

        public override void Enter()
        {
            base.Enter();
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