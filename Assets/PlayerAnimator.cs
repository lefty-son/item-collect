using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {

    private enum MOVE_STATE {
        IDLE, UP, LEFT, DOWN, RIGHT
    }

    private MOVE_STATE STATE;

    private Animator anim;

    private void Awake()
    {
        anim= GetComponent<Animator>();
        STATE = MOVE_STATE.IDLE;
    }

    private void CheckState(){
        switch(STATE){
			case MOVE_STATE.IDLE:
                ToIdle();
				break;
            case MOVE_STATE.UP:
                ToUp();
                break;
            case MOVE_STATE.LEFT:
                ToLeft();
                break;
            case MOVE_STATE.DOWN:
                ToDown();
                break;
            case MOVE_STATE.RIGHT:
                ToRight();
                break;
            default:
                ToIdle();
                break;
        }
    }

    public void ToIdle(){
        anim.SetBool("UP", false);
        anim.SetBool("LEFT", false);
        anim.SetBool("DOWN", false);
        anim.SetBool("RIGHT", false);
    }

    public void ToUp(){
        anim.SetBool("UP", true);
    }

    public void ToLeft()
    {
        anim.SetBool("LEFT", true);
    }

    public void ToDown()
    {
        anim.SetBool("DOWN", true);
    }

    public void ToRight()
    {
        anim.SetBool("RIGHT", true);
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.W)){
            STATE = MOVE_STATE.UP;
        }
        else if(Input.GetKey(KeyCode.A)){
            STATE = MOVE_STATE.LEFT;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            STATE = MOVE_STATE.DOWN;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            STATE = MOVE_STATE.RIGHT;
        }
        else {
            STATE = MOVE_STATE.IDLE;
        }
        CheckState();
    }
}
