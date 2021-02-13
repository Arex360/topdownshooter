using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class aidebug : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform point;
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
         agent.destination = point.position;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
