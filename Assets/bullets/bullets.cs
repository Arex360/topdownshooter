using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName="Bullets", menuName="Bullet", order = 1)]
public class bullets : ScriptableObject
{
    public float fireRate;
    public GameObject Bullets;
    public float damage;
    public float speed;


}
