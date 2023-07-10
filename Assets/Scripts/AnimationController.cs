using UnityEngine.InputSystem;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] private InputActionReference moveLeft;
    [SerializeField] private InputActionReference moveRight;
    [SerializeField] private Animator animator;

    private void OnEnable(){
        moveRight.action.started += AnimateLegs;
        moveRight.action.canceled += StopAnimation;
        moveLeft.action.started += AnimateLegs;
        moveLeft.action.canceled += StopAnimation;
    }

    private void OnDisable(){
        moveRight.action.started -= AnimateLegs;
        moveRight.action.canceled -= StopAnimation;
        moveLeft.action.started -= AnimateLegs;
        moveLeft.action.canceled -= StopAnimation;
    }   

    private void AnimateLegs(InputAction.CallbackContext obj){
        bool isMovingForward = moveRight.action.ReadValue<Vector2>().y > 0 || moveLeft.action.ReadValue<Vector2>().y > 0;

        if(isMovingForward){
            animator.SetBool("IsWalking", true);
            animator.SetFloat("Speed", 1);
        }
        else{
            animator.SetBool("IsWalking", true);
            animator.SetFloat("Speed", -1);
        }
    } 
    
    private void StopAnimation(InputAction.CallbackContext obj){
        animator.SetBool("IsWalking", false);
        animator.SetFloat("Speed", 0);
    }
}
