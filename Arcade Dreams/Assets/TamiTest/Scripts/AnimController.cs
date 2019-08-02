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
        }else
        {
            animator.SetBool("Walking", false);
        }
        if (Mathf.Abs(targetPos.x - pos.x) > Mathf.Abs(targetPos.y - pos.y))
        {
            animator.SetBool("Horizontal", true);
            if (targetPos.x > pos.x)
            {
                animator.SetBool("Right", true);
                animator.SetBool("Left", false);
            }
            else
            {
                animator.SetBool("Right", false);
                animator.SetBool("Left", true);
            }
        }else
        {
            animator.SetBool("Horizontal", false);
            if (targetPos.y > pos.y)
            {
                animator.SetBool("Up", true);
                animator.SetBool("Down", false);
            }
            else
            {
                animator.SetBool("Up", false);
                animator.SetBool("Down", true);
            }
        }
    }
        
}


