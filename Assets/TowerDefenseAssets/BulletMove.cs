using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour {

    private void OnBecameInvisible () {
        Destroy (this.gameObject);
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update () {
        this.transform.Translate (0, 0, 0.05F);
    }
}