using FSM;
using UnityEngine;

namespace Player
{
    public class PRunState : PPatrolState
    {
        public PRunState(string name, StateMachine stateMachine) : base(name, stateMachine)
        {

            

        }
        
        public override void Enter()
        {
            base.Enter();
            EnableWalkingSound();
            
            _speed = _runSpeed; 
            

        }

        public void EnableWalkingSound()
        { 
            _audioSource.loop = true;
            // _audioSource.pitch = 0.56f;
            _audioSource.volume = 0.43f;
            _audioSource.Play();
        }

        public override void UpdateLogic()
        {
            
            base.UpdateLogic();


        }
        


        public override void UpdatePhysics()
        {
            base.UpdatePhysics();
            Vector3 scaledDirect = _direction.normalized * _speed;
     
            
            //2nd way:
            // _rigidbody2D.AddForce(_direction * _speed);
            
            _self.transform.Translate(_direction * _speed* Time.deltaTime);


        }

        public override void Exit()
        {
            base.Exit();
            _audioSource.Stop();
        }
    }
}