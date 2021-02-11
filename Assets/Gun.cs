using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public bullets BulletAsset;
    public List<Transform> gunTip;
    private bool allowFire;
    public FixedJoystick joystick;
    [Range(0,1)]
    public float treshold;
    private Vector2 inputs;
    
    private void Start() {
        allowFire = true;
    }
    // Update is called once per frame
    void Update()
    {
        inputs = new Vector2(joystick.Horizontal, joystick.Vertical);
        if(inputs.magnitude > treshold && allowFire){
            StartCoroutine(fire());
        }
    }
    private IEnumerator fire(){
        allowFire = false;
        foreach(Transform guntip in gunTip){
            GameObject bull = (GameObject) Instantiate(BulletAsset.Bullets,guntip.position,guntip.rotation);
            bull.GetComponent<bullet>().speed = BulletAsset.speed;
        }
        yield return new WaitForSeconds(1/BulletAsset.fireRate);
        allowFire = true;
    }
}
