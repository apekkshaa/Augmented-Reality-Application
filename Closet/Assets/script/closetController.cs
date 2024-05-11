using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ClosetActivator : MonoBehaviour
{
    [SerializeField] private GameObject closet; // Reference to the "closet" GameObject

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
            // Activate the "closet" GameObject when an image is detected
            closet.SetActive(true);
            isImageDetected = true; // Set a flag to prevent repeated activation
        }
        else if (obj.removed.Count > 0)
        {
            // Deactivate the "closet" GameObject when no images are detected
            closet.SetActive(false);
            isImageDetected = false; // Reset the flag
        }
    }
}
