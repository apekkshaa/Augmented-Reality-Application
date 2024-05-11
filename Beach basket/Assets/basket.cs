using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class BasketActivator : MonoBehaviour
{
    [SerializeField] private GameObject basket; // Reference to the "basket" GameObject

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
            // Activate the "basket" GameObject when an image is detected
            basket.SetActive(true);
            isImageDetected = true; // Set a flag to prevent repeated activation
        }
        else if (obj.removed.Count > 0)
        {
            // Deactivate the "basket" GameObject when no images are detected
            basket.SetActive(false);
            isImageDetected = false; // Reset the flag
        }
    }
}
