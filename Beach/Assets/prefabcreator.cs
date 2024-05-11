using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class BeachActivator : MonoBehaviour
{
    [SerializeField] private GameObject beach; // Reference to the "beach" GameObject

    private ARTrackedImageManager aRTrackedImageManager;
    private bool isImageDetected = false;

    private void OnEnable()
    {
        aRTrackedImageManager = gameObject.GetComponent<ARTrackedImageManager>();
        aRTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs obj)
    {
        if (obj.added.Count > 0 && !isImageDetected)
        {
            // Activate the "beach" GameObject when an image is detected
            beach.SetActive(true);
            isImageDetected = true; // Set a flag to prevent repeated activation
        }
        else if (obj.removed.Count > 0)
        {
            // Deactivate the "beach" GameObject when no images are detected
            beach.SetActive(false);
            isImageDetected = false; // Reset the flag
        }
    }
}
