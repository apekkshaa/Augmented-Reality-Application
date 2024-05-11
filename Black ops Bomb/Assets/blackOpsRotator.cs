using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class BeachActivator : MonoBehaviour
{
    [SerializeField] private GameObject blackOps; // Reference to the "blackOps" GameObject

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
            // Activate the "blackOps" GameObject when an image is detected
            blackOps.SetActive(true);
            isImageDetected = true; // Set a flag to prevent repeated activation
        }
        else if (obj.removed.Count > 0)
        {
            // Deactivate the "blackOps" GameObject when no images are detected
            blackOps.SetActive(false);
            isImageDetected = false; // Reset the flag
        }
    }
}
