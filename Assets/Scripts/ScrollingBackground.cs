using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScrollingBackground : MonoBehaviour
{

    public Transform cameraTransform; // Main camera
    public float backgroundSize; // Taille horizontal du layer
    public float paralaxSpeed;
    public bool paralax;
    public bool scrolling;

    private Transform[] layers; // Liste des layers enfants
    private float viewZone = 10; // Limite horizontal pour lancer le scrolling
    private float lastCameraX;
    private int leftIndex;
    private int rightIndex;

    // Use this for initialization
    void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraX = cameraTransform.position.x;

        // Recuperation des layer enfant
        layers = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            layers[i] = transform.GetChild(i);
        }

        // Initialisation des index
        rightIndex = 0;
        leftIndex = transform.childCount - 1;
    }

    private void Update()
    {

        // Paralax Part
        if (paralax)
        {
            float deltaX = cameraTransform.position.x - lastCameraX;
            transform.position = Vector2.right * (deltaX * paralaxSpeed);
        }

        lastCameraX = cameraTransform.position.x;

        // SCrolling Part
        if (scrolling)
        {
            if (cameraTransform.position.x < layers[leftIndex].position.x + viewZone)
            {
                ScollingLeft();
            }

            if (cameraTransform.position.x > layers[rightIndex].position.x - viewZone)
            {
                ScollingRight();
            }
        }
    }

    // Methode de scrolling left
    void ScollingLeft()
    {
        layers[rightIndex].position = Vector3.right * (layers[leftIndex].position.x - backgroundSize);
        leftIndex = rightIndex;
        rightIndex--;

        if (rightIndex < 0)
        {
            rightIndex = layers.Length - 1;
        }
    }

    // Methode de scrolling right
    void ScollingRight()
    {
        layers[leftIndex].position = Vector3.right * (layers[rightIndex].position.x + backgroundSize);
        rightIndex = leftIndex;
        leftIndex++;

        if (leftIndex == layers.Length)
        {
            leftIndex = 0;
        }
    }
}