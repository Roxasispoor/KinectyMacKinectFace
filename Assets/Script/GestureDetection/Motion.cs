using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public bool NewBelongs(Vector3 newPosition,Vector3 previous, Vector3 Origin)
    {
        Vector3 deltaPos = (newPosition - previous);
        //Debug.Log(deltaPos.x);
        Vector3 fromOrigin = newPosition - Origin;
        bool isInMargin = true;
        if (!(marginOfError.x>0 && Mathf.Abs(fromOrigin.x)<marginOfError.x))
        {
            return false;
        }
        if (!(marginOfError.y > 0 && Mathf.Abs(fromOrigin.y) < marginOfError.y))
        {
            return false;
        }
        if (!(marginOfError.z > 0 && Mathf.Abs(fromOrigin.z) < marginOfError.z))
        {
            return false;
        }
        return isInMargin && 
            (deltaPos.x > speedMin * Time.deltaTime * direction.x &&
            deltaPos.y > speedMin * Time.deltaTime * direction.y && 
            deltaPos.z > speedMin * Time.deltaTime * direction.z)  
            || deltaPos.magnitude < threshold;
        //Si on va dans le bon sens a la bonne vitesse ou que on bouge pas trop
    }
	// Use this for
}
