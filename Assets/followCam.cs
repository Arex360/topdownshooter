using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCam : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float speed;
    private Vector3 velocity;
    
    void Start()
    {
        velocity = Vector3.zero;
        player =  GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = player.position + offset;
        //this.transform.position = Vector3.Lerp(this.transform.position,position,speed * Time.deltaTime);
        this.transform.position = Vector3.SmoothDamp(this.transform.position,position,ref velocity,1 / speed);
    }
}
