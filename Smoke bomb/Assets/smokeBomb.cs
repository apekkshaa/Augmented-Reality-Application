using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class SmokeBombActivator : MonoBehaviour
{
    [SerializeField] private GameObject smokeBomb; // Reference to the "smokeBomb" GameObject

    private ARTrackedImageManager aRTrackedImageManager;
    private bool isImageDetected = false;

    private void OnEnable()
    {
        aRTrackedImageManager = GetComponent<ARTrackedImageManager>();
        aRTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs obj)
    {
        if (obj.added.Count > 0 && !isImageDetected)
        {
            // Activate the "smokeBomb" GameObject when an image is detected
            smokeBomb.SetActive(true);
            isImageDetected = true; // Set a flag to prevent repeated activation
        }
        else if (obj.removed.Count > 0)
        {
            // Deactivate the "smokeBomb" GameObject when no images are detected
            smokeBomb.SetActive(false);
            isImageDetected = false; // Reset the flag
        }
    }
}
