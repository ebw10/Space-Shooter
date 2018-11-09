using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Do_A_Barrel_Roll : MonoBehaviour {

    public float dodge;
    public float smoothing;
    public float tilt;
    public Vector2 startWait;
    public Vector2 man_Time;
    public Vector2 man_Wait;
    public Boundary boundary;

    private float currentSpeed;
    private float target_Man;
    private Rigidbody rb;
	
	void Start ()
    {
        rb = GetComponent<Rigidbody> ();
        currentSpeed = rb.velocity.z;
        StartCoroutine (Evade());
	}

     IEnumerator Evade()
    {
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));

        while (true)
        {
            target_Man = Random.Range(1, dodge) * -Mathf.Sign(transform.position.x);
            yield return new WaitForSeconds(Random.Range(man_Time.x, man_Time.y));
            target_Man = 0;
            yield return new WaitForSeconds(Random.Range(man_Wait.x, man_Wait.y));
        }
    }
	
	
	void FixedUpdate ()
    {
        float newMan = Mathf.MoveTowards(rb.velocity.x, target_Man, Time.deltaTime * smoothing);
        rb.velocity = new Vector3(newMan, 0.0f, currentSpeed);
        rb.position = new Vector3
            (
            Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)
            );

        rb.rotation = Quaternion.Euler(0.0f, 0.0f, rb.velocity.x * -tilt);
	}
}
