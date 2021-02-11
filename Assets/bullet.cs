﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private Rigidbody rigidbody;
    public float speed;
    public float lifeTime;
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
        Destroy(this.gameObject,lifeTime);
    }

    // Update is called once per frame
    private void FixedUpdate() {
        rigidbody.velocity = this.transform.forward * speed * Time.fixedDeltaTime;
    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("obs")){
            Destroy(other.gameObject);
        }
    }
}
