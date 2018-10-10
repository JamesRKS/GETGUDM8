using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour {
    public Transform FirePoint;
    public GameObject Projectile;


	//Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.S))
            Instantiate(Projectile, FirePoint.position, FirePoint.rotation);
    }
	
}