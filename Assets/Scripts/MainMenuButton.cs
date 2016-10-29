﻿using UnityEngine;
using System.Collections;

public class MainMenuButton : PhysicalButton {

    public float raisedHeight = 1f;

	private Vector3 initialPos;

    new void Start() {
        base.Start();
        initialPos = transform.position;
    }

    protected override void HandleHover ()
    {
		transform.position = Vector3.MoveTowards(transform.position, initialPos + transform.up*raisedHeight, Time.deltaTime*15f);
        base.HandleHover ();
    }

    protected override void HandleNormal ()
    {
		transform.position = Vector3.MoveTowards(transform.position, initialPos, Time.deltaTime*15f);
        base.HandleNormal ();
    }

    protected override void HandlePressed ()
    {
        base.HandlePressed ();
        StopCoroutine(ButtonPressed());
        StartCoroutine(ButtonPressed());
    }

    private IEnumerator ButtonPressed() {
        float timer = 0f;
        Vector3 startingScale = transform.localScale;
        transform.localScale *= 1.5f;

        while (timer < 1f) {
            timer += Time.deltaTime;
            transform.localScale = Vector3.Lerp(transform.localScale, startingScale, timer);
            yield return new WaitForEndOfFrame();
        }
    }
}