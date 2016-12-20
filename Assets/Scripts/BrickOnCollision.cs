using UnityEngine;
using System.Collections;

public class BrickOnCollision : MonoBehaviour
{

    public float explosiveForce;
    public float explosionRadius;
    private MoveSphere move;
    public GameObject particle;
    public GameObject explosion;

	// Use this for initialization
	void Start ()
	{
	    explosiveForce = 100.0f;
	    explosionRadius = 5.0f;
        GameObject ball = GameObject.Find("Ball");
        move = ball.GetComponent<MoveSphere>();
	    particle = GameObject.Find("SparkEmitter");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.name == "Ball")
        {
            Rigidbody body = GetComponent<Rigidbody>();

            body.AddExplosionForce(explosiveForce*move.speed, collision.transform.position, explosionRadius*move.speed);

            GameObject newParticle = Instantiate(particle, transform.position, Quaternion.identity) as GameObject;

            newParticle.GetComponent<ParticleSystem>().Play();
            newParticle.GetComponent<AudioSource>().Play();
        }

    }
}
