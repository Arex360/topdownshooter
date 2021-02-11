using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunsInventory : MonoBehaviour
{
    private int totalGuns;
    private int currentIndex;
    public List<GameObject> guns;
    void Start()
    {
        totalGuns = guns.Count;
        currentIndex = 0;
        guns[currentIndex].SetActive(true);
    }

    // Update is called once per frame
    public void reset(){
        foreach(GameObject gun in guns){
            gun.SetActive(false);
        }
    }
    public void nextWeapon(){
        reset();
        if(currentIndex < totalGuns -1){
            currentIndex++;
            guns[currentIndex].SetActive(true);
        }else{
            currentIndex = 0;
            guns[currentIndex].SetActive(true);
        }
    }
    public void prevWeapon(){
        reset();
        if(currentIndex < totalGuns){
            currentIndex--;
            if(currentIndex <= 0){
                currentIndex = totalGuns -1;
                guns[currentIndex].SetActive(true);
            }
            guns[currentIndex].SetActive(true);
            
        }else if(currentIndex <= 0){
            currentIndex = 0;
            guns[currentIndex].SetActive(true);
        }
    }
}
