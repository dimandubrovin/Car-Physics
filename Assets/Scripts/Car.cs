using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour
{

    private Rigidbody rb;

    [Header("CAR SPECS")]
    public float wheelRadius;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
}
