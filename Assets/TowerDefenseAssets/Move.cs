using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    float speed = 0.5f, turnSpeed = 1.0f;
    public bool dead = false, lookingForHome = true;
    GameObject home;
    Animator anim;
    // Start is called before the first frame update
    void Start () {
        anim = this.GetComponent<Animator> ();
        InvokeRepeating ("FindHome", 0, 1);
    }

    // Update is called once per frame
    void Update () {

        if (dead) return;
        if (home != null) {
            Vector3 direction = home.transform.position - this.transform.position;
            this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), turnSpeed * Time.smoothDeltaTime);
        } else if (lookingForHome) {
            InvokeRepeating ("FindHome", 0, 1);
            lookingForHome = false;
        }
        this.transform.Translate (0, 0, speed * Time.deltaTime);
    }

    void FindHome () {
        home = GameObject.FindWithTag ("home");
        if (home != null) {
            CancelInvoke ();
            lookingForHome = true;
        }
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter (Collider collider) {
        if (collider.gameObject.tag == "bullet") {
            Hit ();
        } else if (collider.gameObject.tag == "home") {
            Destroy (this.gameObject, 1);
            this.GetComponent<AudioSource> ().Play ();

        }
    }

    void Hit () {
        dead = true;
        anim.SetTrigger ("IsDying");
        Destroy (this.GetComponent<Collider> (), 1);
        Destroy (this.GetComponent<Rigidbody> (), 1);
        Destroy (this.gameObject, 0.1F);
    }
}