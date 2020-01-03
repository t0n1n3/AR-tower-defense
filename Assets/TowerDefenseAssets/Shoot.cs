using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    float turnSpeed = 1.0f;
    public GameObject bullet;
    public GameObject spawnPos;
    GameObject goob;

    // Start is called before the first frame update
    void Start () {
        // InvokeRepeating ("ShootBullet", 0, 1);
    }

    // Update is called once per frame
    void Update () {

        if (goob) {
            Vector3 direction = goob.transform.position - this.transform.position;
            this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), turnSpeed * Time.smoothDeltaTime);
        }
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter (Collider collider) {
        if (collider.gameObject.tag == "goober" && goob == null) {
            goob = collider.gameObject;
            InvokeRepeating ("ShootBullet", 0, 3.0f);
        }
    }

    /// <summary>
    /// OnTriggerExit is called when the Collider other has stopped touching the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerExit (Collider other) {
        if (other.gameObject == goob) {
            goob = null;
            CancelInvoke ("ShootBullet");
        }
    }

    void ShootBullet () {
        Instantiate (bullet, spawnPos.transform.position, spawnPos.transform.rotation);
        this.GetComponent<AudioSource> ().Play ();
        if (goob.GetComponent<Move> ().dead) {
            goob = null;
            CancelInvoke ("ShootBullet");
        }
    }

}