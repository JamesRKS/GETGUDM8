using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour {

    public levelManager levelManager;

	//Use this for initialization
    void Start () {
        levelManager = Find;
    }
	
}