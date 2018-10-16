using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gesture  {
    public List<GameObject> concernedPoints;
    Dictionary<GameObject,List<Motion>> motions;
    Dictionary<GameObject, List<Vector3>> position;
    int currentMotion = 0;
    // Use this for initialization
	public Gesture(List<GameObject> concernedPoints)
    {
        motions = new Dictionary<GameObject, List<Motion>>();
        position = new Dictionary<GameObject, List<Vector3>>();
        this.concernedPoints = concernedPoints;
        foreach (GameObject point in concernedPoints)
        {
            position.Add(point, new List<Vector3>());
            motions.Add(point, new List<Motion>()); 
        }

    }
    public void AddMotionToGameObject(GameObject obj,float speedMin, Vector3 direction, float distanceMin, float threshold, Vector3 marginOfError)
    {
        motions[obj].Add(new Motion(speedMin, direction, distanceMin, threshold,marginOfError));
    }
    public void ActualiseValues()
    {
        foreach(GameObject point in concernedPoints)
        {

            // if(motions[point][currentMotion].NewBelongs(point.transform.position,position[point][position[point].Count]))//si il appartient bien on l'ajoute
            //{
            position[point].Add(point.transform.position);
            if (position[point].Count > 1)
            {
                if (motions[point][currentMotion].NewBelongs(point.transform.position, position[point][position[point].Count - 2],position[point][0])) //Si la distance est supérieure a la distance min du motion on passe au suivant
                {
                    if (currentMotion == motions[point].Count - 1 && (position[point][position[point].Count - 1] - position[point][0]).magnitude > motions[point][currentMotion].distanceMin) // Si c'était le dernier
                    {
                        Debug.Log("MOUVEMENT détectée!");
                        position[point].Clear();
                        currentMotion = 0;
                    }
                }
                else
                {
                    if (currentMotion < motions[point].Count-1 && (motions[point][currentMotion + 1].NewBelongs(point.transform.position, position[point][position[point].Count - 1], position[point][0])) &&
                            (position[point][position[point].Count - 2] - position[point][0]).magnitude > motions[point][currentMotion].distanceMin) // on est dans le mouvement d'après et on avait fais assez
                    {
                        currentMotion++;
                        position[point].Clear();
                        position[point].Add(point.transform.position);
                    }
                    else
                    {
                        position[point].Clear();
                        Debug.Log("connard, suis le mouvement!");
                        currentMotion = 0;
                    }
                }
            }
                
        }
        
    }
}
