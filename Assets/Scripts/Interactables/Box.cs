using UnityEngine;
using DreamEscape;
using DreamEscape.Utilities;
using DreamEscape.Extensions;
using System;

public class Box : InteractableObject {

    // Use this for initialization
    protected override void Start() {
        base.Start();
    }

    // Update is called once per frame
    void Update() {

    }


    public override void Interact() {
        print("Interact with: " + gameObject.name);
    }
}
