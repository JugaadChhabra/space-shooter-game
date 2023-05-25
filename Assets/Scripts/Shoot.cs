using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public bool isShoot;

    [Header("Missile")]
    public GameObject missile;
    public GameObject MuzzleFlash;
    public Transform MissileSpawnPosition;
    public Transform MuzzleSpawnPosition;
    

    public void ButtonClicked()
    {
        isShoot = true;
        InvokeRepeating("missileShoot",0f,0.3f);
    }

    public void ButtonReleased()
    {
        isShoot = false;
        CancelInvoke("missileShoot");
    }

    // public void SShoot()
    // {
    // //    PlayerController.missileShoot();
    // }

    public void missileShoot()
    {
        // if (MissileCount.mcount != 0)
        // PlayerController.shoot.Play();
        SpawnMuzzleFlash();
        SpawnMissile();
        MissileCount.mcount -= 1;
    }
    
    void PlayerShoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnMissile();
            SpawnMuzzleFlash();
        }
    }

    public void SpawnMissile()
    {
        GameObject gm = Instantiate(missile, MissileSpawnPosition);
        gm.transform.SetParent(null);
        Destroy(gm, PlayerController.DestroyTime);
    }

    public void SpawnMuzzleFlash()
    {
        GameObject muzzle = Instantiate(MuzzleFlash, MuzzleSpawnPosition);
        muzzle.transform.SetParent(null);
        Destroy(muzzle, PlayerController.DestroyTime);
    }
}
