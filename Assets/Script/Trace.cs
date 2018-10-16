using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Trace : MonoBehaviour {
    string path = "Assets/logPosition.txt";
   public bool isTracked;
    // Use this for initialization
    StreamWriter writer;
    float current=0;
    void Start () {
     //   writer = new StreamWriter(path);
        
    }
	
	// Update is called once per frame
	void Update () {
        /*if(isTracked)
        {

            writer.WriteLine("X : " + transform.position.x + ";Y : " + transform.position.y + ";Z : " + transform.position.z + ";time: " + (Time.fixedTime-current));
            current = Time.fixedTime;
        }*/
    }
    private void OnDestroy()
    {
 //       writer.Close();
    }
}
