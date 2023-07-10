using UnityEngine;

public class LowerBodyAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] [Range(0,2)] private float leftFootPositionWeight;
    [SerializeField] [Range(0,2)] private float rightFootPositionWeight;

    [SerializeField] [Range(0,1)] private float leftFootRotationWeight;
    [SerializeField] [Range(0,1)] private float rightFootRotationWeight;

    [SerializeField] private Vector3 footOffset;
    [SerializeField] private Vector3 raycastLeftOffset;
    [SerializeField] private Vector3 raycastRightOffset;

    private void OnAnimatorIK(int layerIndex){
        Vector3 leftFootPosition = this.animator.GetIKPosition(AvatarIKGoal.LeftFoot);
        Vector3 rightFootPosition = this.animator.GetIKPosition(AvatarIKGoal.RightFoot);

        RaycastHit hitLeftFoot;
        RaycastHit hitRightFoot;

        bool isLeftFootDown = Physics.Raycast(leftFootPosition + this.raycastLeftOffset, Vector3.down, out hitLeftFoot);
        bool isRightFootDown = Physics.Raycast(rightFootPosition + this.raycastRightOffset, Vector3.down, out hitRightFoot);

       CalculateLeftFoot(isLeftFootDown, hitLeftFoot);
       CalculateRightFoot(isRightFootDown, hitRightFoot);
    }

    void CalculateLeftFoot(bool isLeftFootDown, RaycastHit hitLeftFoot){
       if(isLeftFootDown){
            this.animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, this.leftFootPositionWeight);
            this.animator.SetIKPosition(AvatarIKGoal.LeftFoot, hitLeftFoot.point + this.footOffset);

            Quaternion leftFootRotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(transform.forward, hitLeftFoot.normal), hitLeftFoot.normal);

            this.animator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, this.leftFootRotationWeight);
            this.animator.SetIKRotation(AvatarIKGoal.LeftFoot, leftFootRotation);
        }
        else{
            this.animator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 0);
        } 
    }

     void CalculateRightFoot(bool isRightFootDown, RaycastHit hitRightFoot){
       if(isRightFootDown){
            this.animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, this.rightFootPositionWeight);
            this.animator.SetIKPosition(AvatarIKGoal.RightFoot, hitRightFoot.point + this.footOffset);

            Quaternion rightFootRotation = Quaternion.LookRotation(Vector3.ProjectOnPlane(transform.forward, hitRightFoot.normal), hitRightFoot.normal);

            this.animator.SetIKRotationWeight(AvatarIKGoal.RightFoot, this.rightFootRotationWeight);
            this.animator.SetIKRotation(AvatarIKGoal.RightFoot, rightFootRotation);
        }
        else{
            this.animator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 0);
        } 
    }
}
