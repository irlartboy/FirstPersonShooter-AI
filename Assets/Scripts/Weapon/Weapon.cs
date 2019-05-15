using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int damage = 10, maxReserve = 500, maxClip = 30;
    public float spread = 2f, recoil = 1f, range = 10f, shootRate = .2f;
    public Transform shotOrigin;
    public GameObject bulletPrefab;
    public bool canShoot = false;

    private int currentReserve = 0, currentClip = 0;
    private float shootTimer = 0f;

    void Start()
    {
        Reload();    
    }

    void Update()
    {
        // increase the shootTimer 
        shootTimer += Time.deltaTime;
        //Check if shoot timwe reaches the rate

        if (shootTimer >= shootRate)
        {
            // Can Shoot
            canShoot = true;
        }
    }

   public void Reload()
    {
        // if there are bullets left in reserve
        if (currentReserve > 0)
        {
            // if there is enough bullets in reserve to fill a clip
            if (currentReserve >= maxClip)
            {
                // reduce the clip size by the offset from the current clip to max clip
                int offset = maxClip - currentClip;
                currentReserve -= offset;
            }
            //if clip is below max clip
            if (currentReserve < maxClip)
            {
                int tempMag = currentReserve;
                currentClip = tempMag;
                currentReserve -= tempMag;
            }
        }
    }

   public void Shoot()
    {
        // reduce clip size
        currentClip--;
        //reset shoot timer
        shootTimer = 0f;
        //reset canShoot
        canShoot = false;
        // Get origin + direction of fire
        Camera attachedCamera = Camera.main;
        Transform camTransform = attachedCamera.transform;
        Vector3 lineOrigin = shotOrigin.position;
        Vector3 direction = camTransform.forward;
        //shoot bullet
        GameObject clone = Instantiate(bulletPrefab, camTransform.position, camTransform.rotation);
        Bullet bullet = clone.GetComponent<Bullet>();
        bullet.Fire(lineOrigin, direction);
    }
}
