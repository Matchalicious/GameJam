using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI
;
public class WeaponSwitchController : MonoBehaviour
{
    
    public int selectedWeapon = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        SelectWeapon();
    }

    public void weaponOne(){
        selectedWeapon = 0;
        SelectWeapon();
    }

    public void weaponTwo(){
        selectedWeapon = 1;
        SelectWeapon();
    }

    public void weaponThree(){
        selectedWeapon = 2;
        SelectWeapon();
    }

    void SelectWeapon(){
        int i = 0;
        foreach (Transform weapon in transform){
            if (i == selectedWeapon){
                weapon.gameObject.SetActive(true);
            }
            else{
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
