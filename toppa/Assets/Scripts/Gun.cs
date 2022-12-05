using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
    {
        public GameObject Bullet;
        public Crosshair crosshair; // put the UI crosshair object into this field in the inspector
        public float gunRecoil;
        public float settleSpeed;
        public float shotsPerSecond; //how fast this gun shoots
        private int index; // The index of bullets
        private int magzineSize = 30;
        private int BulletSpeed = 800;
        public Camera playercamera;



        //used to set up how often the gun shoots as set in shotsPerSecond 
        float shotRate;
        float nextShotTime;
        public int ammo;
        public int leftammo;

        void Start()
        {

            crosshair.SetShrinkSpeed(settleSpeed);
            index = 0;

            //set up the gunshooting speed in this script
            shotRate = 1.0f / shotsPerSecond;
            nextShotTime = 0f;
            ammo = magzineSize;
            leftammo = magzineSize * 4;

        }

        void Update()
        {
            if (Input.GetButton("Fire1")) {
                Shoot();
            } // press the mouse1 / left control / controller button 1 to simulate shooting with the given recoil
            //Input.GetKeyDown(KeyCode.Mouse0)
            if (Input.GetKeyDown("r")) {
                Reload();
            }
        }

        void Shoot() //shoot the gun based on the fire rate set by setting shotsPerSecond
        {
            if (nextShotTime < Time.time && ammo > 0) {
                // Fire the bullet
                index++;
                GameObject actualbullet = Instantiate(Bullet);
                actualbullet.name = "Bullet" + index;
                actualbullet.transform.parent = this.transform;
                actualbullet.transform.localPosition = new Vector3(0,0,(float)0.5);
                // actualbullet.transform.rotation = playercamera.transform.rotation;
                actualbullet.transform.DetachChildren();
                actualbullet.GetComponent<Rigidbody>().AddForce(this.transform.forward * BulletSpeed);
                Destroy(actualbullet, 2f);
                // Modify the Crosshair
                crosshair.Expand(gunRecoil);
                nextShotTime = Time.time + shotRate;
                // Reduce left ammo
                ammo -= 1;
            }

        }

        void Reload() //Reload the current gun
        {   
            if (ammo < magzineSize && leftammo > 0) {
                if (leftammo < magzineSize - ammo) {
                    ammo += leftammo;
                    leftammo = 0;
                } else {
                    leftammo -= magzineSize - ammo;
                    ammo = magzineSize;  
                }
               
            }
        }

    }
