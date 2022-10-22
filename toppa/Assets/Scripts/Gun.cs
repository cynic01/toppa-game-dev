using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HELLSLAYERCrosshairs
{
    public class Gun : MonoBehaviour
    {
        public GameObject Bullet;
        public Crosshair crosshair; //put the UI crosshair object into this field in the inspector
        public float gunRecoil;
        public float settleSpeed;
        public float shotsPerSecond; //how fast this gun shoots
        private int index; // The index of bullets
        private int BullentSpeed = 800;
        public Camera playercamera;



        //used to set up how often the gun shoots as set in shotsPerSecond 
        float shotRate;
        float nextShotTime;

        void Start()
        {

            crosshair.SetShrinkSpeed(settleSpeed);
            index = 0;

            //set up the gunshooting speed in this script
            shotRate = 1.0f / shotsPerSecond;
            nextShotTime = 0f;

        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0)) // press the mouse1 / left control / controller button 1 to simulate shooting with the given recoil
                Shoot();
        }

        void Shoot() //shoot the gun based on the fire rate set by setting shotsPerSecond
        {
            if (nextShotTime < Time.time) {
                // Fire the bullet
                index ++;
                GameObject actualbullet = Instantiate(Bullet);
                actualbullet.name = "Bullet" + index;
                actualbullet.transform.parent = this.transform;
                actualbullet.transform.localPosition = new Vector3(0,0,(float)0.5);
                // actualbullet.transform.rotation = playercamera.transform.rotation;
                actualbullet.transform.DetachChildren();
                actualbullet.GetComponent<Rigidbody>().AddForce( this.transform.forward * BullentSpeed);
                Destroy(actualbullet, 2f);
                // Modify the Crosshair
                crosshair.Expand(gunRecoil);
                nextShotTime = Time.time + shotRate;
            }

        }
    }
}
