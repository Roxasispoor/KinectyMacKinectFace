using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Motion {
    public float threshold;
    public float speedMin;
    public Vector3 direction;
    public float distanceMin;
    public Vector3 marginOfError;
    
    public Motion(float speedMin,Vector3 direction,float distanceMin, float threshold, Vector3 marginOfError)
    {
        this.threshold = threshold;
        this.speedMin = speedMin;
        this.direction = direction;
        this.distanceMin = distanceMin;
        this.marginOfError = marginOfError;
    }
    public bool NewBelongs(Vector3 newPosition,Vector3 previous, Vector3 Origin,int currentMotion)
    {
        Vector3 deltaPos = (newPosition - previous);
        //Debug.Log(deltaPos.x);
        Vector3 fromOrigin = newPosition - Origin;
        bool isInMargin = true;
        bool conditionSpeed=false;

        if(deltaPos.magnitude < threshold)
        {
            return true;
        }
        if(currentMotion==1)
        {
            int commandeinutile = 0;
        }
        if (marginOfError.x>0 )
        {
            if(Mathf.Abs(fromOrigin.x) > marginOfError.x)
            {
                isInMargin = false;
            }
        }
        else if(Mathf.Sign(deltaPos.x)== Mathf.Sign(direction.x) && Mathf.Abs(deltaPos.x) > speedMin * Time.deltaTime )
        {
            conditionSpeed = true;
        }
        else
        {
            return false;
        }

        if (marginOfError.y > 0)
        {
            if (Mathf.Abs(fromOrigin.y) > marginOfError.y)
            {
                return false;
            }
        }
        else if (Mathf.Sign(deltaPos.y) == Mathf.Sign(direction.y) && Mathf.Abs(deltaPos.y) > speedMin * Time.deltaTime)
        {
            conditionSpeed = true;
        }
        else
        {
            return false;
        }

        if (marginOfError.z > 0)
        {
            if (Mathf.Abs(fromOrigin.z) > marginOfError.z)
            {
                return false;
            }
        }
        else if (Mathf.Sign(deltaPos.z) == Mathf.Sign(direction.z) && Mathf.Abs(deltaPos.z) > speedMin * Time.deltaTime)
        {
            conditionSpeed = true;
        }
        else
        {
            return false;
        }
        return isInMargin && conditionSpeed ;
        //Si on va dans le bon sens a la bonne vitesse ou que on bouge pas trop
    }
	// Use this for
}
