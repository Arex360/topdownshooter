using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCam : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float speed;
    private Vector3 velocity;
    private float minOffset;
    public float maxOffset;
    public float offsetSpeed;
    
    void Start()
    {
        minOffset = offset.y;
        velocity = Vector3.zero;
        player =  GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = player.position + offset;
        //this.transform.position = Vector3.Lerp(this.transform.position,position,speed * Time.deltaTime);
        this.transform.position = Vector3.SmoothDamp(this.transform.position,position,ref velocity,1 / speed);
        if(Input.GetKey(KeyCode.I)){
            Increase();
        }else if(Input.GetKey(KeyCode.O)){
            Decrease();
        }
        offset.y = Mathf.Clamp(offset.y, minOffset,maxOffset);
    }
    private void Increase(){
         offset.y += offsetSpeed * Time.deltaTime;
    }
    private void Decrease(){
        offset.y -= offsetSpeed * Time.deltaTime;
    }

}
