using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Gravity : MonoBehaviour
{
    Rigidbody rb;
    const float G = 0.006674f;//Gravitational Constant 6.674
    
    //create a List of objects in the galaxy to attract
    public static List<Gravity> planetLists;
   
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (planetLists == null)
        {
            planetLists = new List<Gravity>();
        }

        planetLists.Add(this);
    }

    private void FixedUpdate()
    {
        foreach (var planet in planetLists)
        {
            if(planet != this)
               Attract(planet);
        }
    }

    void Attract(Gravity other)
    {
        Rigidbody otherRb = other.rb;
        Vector3 direction = rb.position - otherRb.position;
        float distance = direction.magnitude;
        
        float forceMagnitude = G * ((rb.mass * otherRb.mass)/Mathf.Pow(distance, 2));
        Vector3 finalForce = forceMagnitude * direction.normalized;
        otherRb.AddForce(finalForce);

    }
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
