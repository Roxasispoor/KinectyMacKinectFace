using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gesture : MonoBehaviour {
    public List<GameObject> concernedPoints;
    Dictionary<GameObject,List<Motion>> motions;
    Dictionary<GameObject, List<Vector3>> position;
    public float threshHold;
    int currentMotion = 0;
    // Use this for initialization
	void Start () {
        foreach (GameObject point in concernedPoints)
        {
            position[point] = new List<Vector3>();
        }

    }
    public void ActualiseValues()
    {
        foreach(GameObject point in concernedPoints)
        {
           
               // if(motions[point][currentMotion].NewBelongs(point.transform.position,position[point][position[point].Count]))//si il appartient bien on l'ajoute
                //{
                    position[point].Add(point.transform.position);
               
                if((position[point][position[point].Count]-position[point][0]).magnitude>motions[point][currentMotion].distanceMin)//Si la distance est supérieure a la distance min du motion on passe au suivant
                {
                    
                    if (currentMotion< motions[point].Count && motions[point][currentMotion+1].NewBelongs(point.transform.position, position[point][position[point].Count]) )//si y en a encore après et qu'on va dans ce sens ou qu'on ne bouge plus trop
                    {
                        currentMotion++;
                    }

                    else if(currentMotion == motions[point].Count) // Si c'était le dernier
                    {
                        Debug.Log("MOUVEMENT détectée!");
                    }
                    else//Sinon le mec fait n'imp; On purge toutes les positions et on revient au premier motion
                    {
                        position[point].Clear();

                    }
                  }
                
            }
        
    }
	// Update is called once per frame
	void Update () {
		
	}
}
