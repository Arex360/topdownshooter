using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public Transform gunTip;

    public float fireRate;
    private bool allowFire;
    
    private void Start() {
        allowFire = true;
    }
    // Update is called once per frame
    void Update()
    {
        if(ControlFreak2.CF2Input.GetKey(KeyCode.Space) && allowFire){
            StartCoroutine(fire());
        }
    }
    private IEnumerator fire(){
        allowFire = false;
        GameObject bull = (GameObject) Instantiate(bullet,gunTip.position,gunTip.rotation);
        yield return new WaitForSeconds(1/fireRate);
        allowFire = true;
    }
}
