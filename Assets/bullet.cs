using System.Collections;
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
    private void OnCollisionEnter(Collision other) {
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter(Collider other) {
        Destroy(this.gameObject);
        if(other.CompareTag("Enemy")){
            Destroy(other.gameObject);
        }
        Destroy(this.gameObject);
    }
}
