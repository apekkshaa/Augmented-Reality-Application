using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class LandMineActivator : MonoBehaviour
{
    [SerializeField] private GameObject landMine; // Reference to the "landMine" GameObject

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
            // Activate the "landMine" GameObject when an image is detected
            landMine.SetActive(true);
            isImageDetected = true; // Set a flag to prevent repeated activation
        }
        else if (obj.removed.Count > 0)
        {
            // Deactivate the "landMine" GameObject when no images are detected
            landMine.SetActive(false);
            isImageDetected = false; // Reset the flag
        }
    }
}
