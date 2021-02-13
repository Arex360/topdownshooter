using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PathScript : MonoBehaviour
{
    private AgentScript agentScript;
    private NavMeshAgent agent;
    public List<Transform> paths;
    public int current;
    public bool onPath;
    public LayerMask mask;
    public float viewRadius;
    void Start()
    {
        agentScript = this.GetComponent<AgentScript>();
        agent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
         Collider[] caught = Physics.OverlapSphere(this.transform.position, viewRadius,mask);
         if(caught.Length > 0){
             agentScript.enabled = true;
              this.enabled = false;
         }
        if(!onPath){
            StartCoroutine(FollowPath());
        }
    }
      private IEnumerator FollowPath(){
           onPath = true;
           agent.SetDestination(paths[current].position);
           yield return new WaitForSeconds(5);
           current = (current + 1) % paths.Count;
           onPath = false;
      }
      private void OnDrawGizmos() {
          Gizmos.color = Color.green;
          for(int i = 0; i < paths.Count;i++){
              if(i < paths.Count-1){
                  Gizmos.DrawLine(paths[i].position,paths[i+1].position);
              }
              if(i == paths.Count -1){
                  Gizmos.DrawLine(paths[i].position, paths[0].position);
              }
          }
      }
}
