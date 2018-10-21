using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameObjectAndMotions {

    public GameObject point;
    public List<Motion> motions;
    public List<Vector3> positions;
    public int currentMotion = 0;

    public GameObjectAndMotions(GameObject point, List<Motion> motions)
    {
        this.point = point;
        this.motions = motions;
        Positions = new List<Vector3>();
    }

    public List<Vector3> Positions
    {
        get
        {
            return positions;
        }

        set
        {
            positions = value;
        }
    }
}
