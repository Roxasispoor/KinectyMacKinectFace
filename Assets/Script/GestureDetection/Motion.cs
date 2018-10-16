using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion {
    public float speedMin;
    public Vector3 direction;
    public float distanceMin;
    public float threshHold;

    public bool NewBelongs(Vector3 newPosition,Vector3 previous)
    {
        Vector3 deltaPos = (newPosition - previous);
        return (deltaPos.x > speedMin * Time.deltaTime * direction.x &&
            deltaPos.y > speedMin * Time.deltaTime * direction.y)  
            || (newPosition - previous).magnitude > threshHold;
        //Si on va dans le bon sens a la bonne vitesse ou que on bouge pas trop
    }
	// Use this for
}
