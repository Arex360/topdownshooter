using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AgentScript : MonoBehaviour
{
    
    public enum AIState{
        idle,path, follow, attack
    }
    public LayerMask mask;
    private NavMeshAgent agent;
    [Header("Basic Properties")]
    public bullets bullets;
    public Transform gunTip;
    public Transform player;
    public PathScript pathScript;
    [Header("AI Properties"),Space]
    public AIState botState;
    public float viewRadius;
    public bool playerCatch;
    
    public int currentPath;
    [Header("Debugg decisions"),Space]
    public bool idleDecison;
    public bool  onPath;
    public float attackRate;
    
    public bool attackDecision;
    public float idleValue;
    public float decisonTime;
    public float attDec;
    public bool allowFire;
    void Start()
    {
        agent = this.GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        allowFire = true;
        pathScript = this.GetComponent<PathScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] caught = Physics.OverlapSphere(this.transform.position, viewRadius,mask);
        if(caught.Length > 0){
            if(!attackDecision){
                StartCoroutine(AttackDecide());
            }
        }else{
            if(!idleDecison){
                StartCoroutine(IdleDecision());
            }
        }
        Actions();

    }
    private void Actions(){
        if(botState == AIState.follow){
            pathScript.enabled = false;
            agent.SetDestination(player.position);
        }else{
            agent.SetDestination(this.transform.position);
        }


        if(botState == AIState.attack){
            pathScript.enabled = false;
            this.transform.LookAt(player.position);
            if(allowFire){
                StartCoroutine(Attack());
            }
        }


        if(botState == AIState.path){
           pathScript.enabled = true;
           this.enabled = false;
        }



    }
    
    private IEnumerator Attack(){
         allowFire = false;
         GameObject bullet = (GameObject) Instantiate(bullets.Bullets,gunTip.position,gunTip.rotation);
         yield return new WaitForSeconds(1/bullets.fireRate);
         allowFire = true;
    }
    private IEnumerator AttackDecide(){
        attackDecision = true;
        attDec = Random.value;
        if(attDec > 0.5f){
            botState = AIState.attack;
        }else{
            botState = AIState.follow;
        }
        decisonTime = Random.value;
        if(decisonTime <= 0.45f){
            //print("Waiting for 5 seconds");
            yield return new WaitForSeconds(5);
        }else if(decisonTime <= 0.82f){
           // print("Waiting for 3 seconds");
            yield return new WaitForSeconds(3);
        }else {
          //  print("Waiting for 1.5 seconds");
            yield return new WaitForSeconds(1.5f);
        }
        attackDecision = false;
    }
    private IEnumerator IdleDecision(){
        idleDecison = true;
         idleValue = Random.value;
        if(idleValue > 0.3){
            botState = AIState.path;
        }else{
            botState = AIState.idle;
        }
        decisonTime = Random.value;
        if(decisonTime <= 0.45f){
            //print("Waiting for 5 seconds");
            yield return new WaitForSeconds(5);
        }else if(decisonTime <= 0.82f){
            //print("Waiting for 3 seconds");
            yield return new WaitForSeconds(3);
        }else {
           // print("Waiting for 1.5 seconds");
            yield return new WaitForSeconds(1.5f);
        }
       
        idleDecison = false;
    }
    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, viewRadius);
    }
}
