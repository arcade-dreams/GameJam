using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnClick : MonoBehaviour
{
    public float minZ = -30;
    public float maxZ = -3;
    private Vector3 target;
    public List<Collider> levelColliders;
    bool getInput = true;
    float inputSuppressTimer = 0.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputSuppressTimer -= Time.deltaTime;
        if(Input.GetMouseButtonDown(0) && getInput == true && inputSuppressTimer < 0)
        {
            Vector3 screenPos = Input.mousePosition;
            //screenPos.z = Camera.main.nearClipPlane;
            screenPos.z = maxZ - Camera.main.transform.position.z;
            target = Camera.main.ScreenToWorldPoint(screenPos);
            Vector3 normPos = new Vector3(screenPos.x / Screen.width, screenPos.y / Screen.height, 0);
            target.z = ( 1 - normPos.y ) * ( minZ - maxZ );
            if(target.z > maxZ)
            {
                target.z = maxZ;
            }
            bool inside = false;
            foreach(Collider c in levelColliders)
            {
                if(IsInside(c, target))
                {
                    inside = true;
                }
            }
            if (!inside)
            {
                float closestDistance = 99999;
                Collider closestCollider = null;
                foreach (Collider c in levelColliders)
                {
                    Vector3 closest = c.ClosestPoint(target);
                    closest.z = target.z;

                    if(closestDistance > (closest - target).sqrMagnitude)
                    {
                        closestDistance = (closest - target).sqrMagnitude;
                        closestCollider = c;
                    }

                }
                Vector3 closestPoint = closestCollider.ClosestPoint(target);
                closestPoint.z = target.z;
                target = closestPoint;
            }
            transform.position = target;
        }
    }
    bool IsInside(Collider c, Vector3 point)
    {
        Vector3 closest = c.ClosestPoint(point);
        closest.z = point.z;
        return closest == point;
    }

    public void ShouldGetInput(bool shouldGetInput)
    {
        getInput = shouldGetInput;
    }

    public void SuppressInput()
    {
        inputSuppressTimer = 1.0f;
    }
}


