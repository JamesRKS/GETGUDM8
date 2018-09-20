using UnityEngine;
using System.Collections;

public class DeathBox : MonoBehaviour {

    void OnTriggerEnter2D (Collider2D other){

        if(other.name == "PC")
        {
            Debug.Log("PC Enters Death Zone");
            Destroy(other);
        }

    }
}