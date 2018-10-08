using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckPoint;
    public Rigidbody2D pc;

    // Particles
    public GameObject DeathParticle;
    public GameObject RespawnParticle;

    //Respawn Delay
    public float RespawnDelay;


    //Point Penalty on Death
    public int PointPenaltyOnDeath;

    // Store Gravity Value
    private float gravityStore;


	// Use this for initialization
	void Start () {
        //pc = FindObjectOfType<Rigidbody2D> ();
	}

    public void RespawnPlayer(){
        StartCoroutine("RespawnPlayerCo");
    }

    public IEnumerator RespawnPlayerCo(){
        //Generate Death Particle
        Instantiate(DeathParticle, pc.transform.position, pc.transform.rotation);
        //Hide Player
        //pc.enabled = false;
        pc.GetComponent<Renderer>().enabled = false;
        // Gravity Reset
        gravityStore = pc.GetComponent<Rigidbody2D>().gravityScale;
        pc.GetComponent<Rigidbody2D>().gravityScale = 0f;
        pc.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        // Point Penalty
        ScoreManager.AddPoints(-PointPenaltyOnDeath);
        //Debug Message
        Debug.Log("Player Respawn");
        //Respawn Delay
        yield return new WaitForSeconds(RespawnDelay);
        //Gravity Restore
        pc.GetComponent<Rigidbody2D>().gravityScale = gravityStore;
        //Match Players transform position
        pc.transform.position = currentCheckPoint.transform.position;
        //Show Player
        //pc.enabled = true;
        pc.GetComponent<Renderer>().enabled = true;
        //Spawn Player
        Instantiate(RespawnParticle, currentCheckPoint.transform.position, currentCheckPoint.transform.rotation);
    }
}