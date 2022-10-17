using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingPlayer : StateMachineBehaviour
{
    public float speed = 5f;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 birdPos = BatEyes.Instance.transform.position;
        Vector3 playerPos = PlayerMovement.Instance.transform.position;
        
        float distance = Vector2.Distance(PlayerMovement.Instance.transform.position, BatEyes.Instance.transform.position);
        animator.SetFloat("DistanceToPlayer", distance);

        Rigidbody2D rb = BatEyes.Instance.rb;
        Rigidbody2D prb = PlayerMovement.Instance.rb;

        Vector2 targ = new Vector2(prb.transform.position.x - 1f, prb.transform.position.y + 1f);

        rb.transform.position = Vector3.MoveTowards(rb.transform.position, targ, 0.05f);

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
