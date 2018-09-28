using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckPoint;
    private Rigidbody2D pc;

    // Particles
    public GameObject DeathParticle;
    public GameObject RespawnParticle;

    //Respawn Delay
    public float RespawnDelay;


    //Point Penalty on Death
    public int PointPenaltyOnDeath;

    // Store Gravity Value
    private float GravityStore;


	// Use this for initialization
	void Start () {
        pc = FindObjectOfType<Rigidbody2D> ();
	}

    public void RespawnPlayer(){
        StartCoroutine("RespawnPCCo");
    }

    public IEnumerator RespawnPCCo(){
        //Generate Death Particle
        Instantiate(DeathParticle, pc.transform.position, pc.transform.rotation);
        //Hide Player
        pc.enabled = false;
        pc.GetComponent<Renderer>().enabled = false;
        // Gravity Reset
        GravityStore = pc.GetComponent<Rigidbody2D>().gravityScale;
        pc.GetComponent<Rigidbody2D>().gravityScale = 0f;
        pc.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        // Point Penalty
        ScoreManager.AddPoints(-PointPenaltyOnDeath);
        //Debug Message
        Debug.Log("Player Respawn");
        //Respawn Delay
        yield return new WaitForSeconds(RespawnDelay);
        //Gravity Restore
        pc.GetComponent<Rigidbody2D>().gravityScale = GravityStore;
    }
}