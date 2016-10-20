using UnityEngine;
using System.Collections;

public class Suspension : MonoBehaviour {

    public Rigidbody rb;

    [Header("SUSPENSION")]
    public float springForce;
    public float damperForce;
    public float springConstant;
    public float damperConstant;
    public float restLenght;

    private float previousLenght;
    private float currentLenght;
    private float springVelocity;
    private Car car;

    void Start () {
        car = transform.parent.GetComponent<Car>();
	}
	
	void FixedUpdate () {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, restLenght + car.wheelRadius))
        {
            previousLenght = currentLenght;
            currentLenght = restLenght - (hit.distance - car.wheelRadius);
            springVelocity = (currentLenght - previousLenght) / Time.fixedDeltaTime;
            springForce = springConstant * currentLenght;
            damperForce = damperConstant * springVelocity;

            rb.AddForceAtPosition(transform.up * (springForce + damperForce), transform.position);
        }
	}
}
