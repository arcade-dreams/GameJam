using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimController : MonoBehaviour
{
    public Transform target;
    public float walkDistance = 1.0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = target.position;
        targetPos.z = 0;
        Vector3 pos = transform.position;
        pos.z = 0;
        float distance = (targetPos - pos).sqrMagnitude;
        Animator animator = gameObject.GetComponent(typeof(Animator)) as Animator;
        if (distance > walkDistance)
        {
            animator.SetBool("Walking", true);
            if (Mathf.Abs(targetPos.x - pos.x) > Mathf.Abs(targetPos.y - pos.y))
            {
                animator.SetBool("Horizontal", true);
                if (targetPos.x > pos.x)
                {
                    RotateSprite(true);
                    animator.SetBool("Right", true);
                }
                else
                {
                    RotateSprite(false);
                    animator.SetBool("Right", false);
                }
            }
            else
            {
                RotateSprite(true);
                animator.SetBool("Horizontal", false);
                if (targetPos.y > pos.y)
                {
                    animator.SetBool("Up", true);
                }
                else
                {
                    animator.SetBool("Up", false);
                }
            }
        }
        else
        {
            animator.SetBool("Walking", false);
        }
    }

    void RotateSprite(bool right)
    {
        Vector3 scale = transform.localScale;
        if ((scale.x < 0 && right) || (scale.x > 0 && !right))
        {
            scale.x *= -1;
        }
        transform.localScale = scale;
    }
        
}



