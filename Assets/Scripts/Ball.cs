using UnityEngine;
using System.Collections;

public class Ball: MonoBehaviour {

	public float speed = 600f;
	public float maxSpeed = 10f;

	public AudioSource thisAudio;
	public Rigidbody2D rb;

	void Start()
	{	
		GetComponent<Rigidbody2D>().AddForce (transform.up * speed);
        thisAudio = GetComponent<AudioSource>();
		rb = GetComponent<Rigidbody2D> ();
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
        thisAudio.Play ();
		if (collision.gameObject.tag == "Platform")
		{
				rb.AddForce (transform.up * speed);
		}
	}

	void FixedUpdate()
	{
		if (rb.velocity.magnitude > maxSpeed)
		{
			rb.velocity = rb.velocity.normalized * maxSpeed;
		}

	}
}
