using System.Collections;
using System.Collections.Generic;
using UnityEngine;
  
public class movementSystem : MonoBehaviour
{
    private Rigidbody rigidbody;
    private Vector2 inputs;
    private Ray ray;
    private RaycastHit hit;
    public float speed;
    public LayerMask mask;
    

    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, Mathf.Infinity,mask)){
            Quaternion targetRotation = Quaternion.LookRotation(hit.point - this.transform.position);
            targetRotation.x = targetRotation.z = 0f;
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, 10f * Time.fixedDeltaTime);
        }
        movment();
    }
    private void movment(){
        inputs = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        rigidbody.velocity = new Vector3(inputs.x * speed * Time.fixedDeltaTime, 0 , inputs.y * speed * Time.fixedDeltaTime);
    }
}
