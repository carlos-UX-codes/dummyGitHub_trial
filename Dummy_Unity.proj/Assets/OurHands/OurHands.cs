using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class OurHands : MonoBehaviour
{
    //public valaues to set in Unity, private used only in script
    public GameObject ourhandPrefab;
    public InputDeviceCharacteristics ourControllerCharacteristics;

    private InputDevice ourDevice; 

    // Start is called before the first frame update
    void Start()
    {
        InitializeOurHand();
    }

    void InitializeOurHand()
    {
        //Check for our controllerscharacteristics
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(ourControllerCharacteristics, devices);

        //If Device indentified, Instantiate a Hand
        if (devices.Count > 0)
        {
            ourDevice = devices[0];
            GameObject newHand = Instantiate(ourhandPrefab, transform);

        }
    }

    // Update is called once per frame
    void Update()
    {
        //Change Animate position or re-initialize 
        if (ourDevice.isValid)
        {
            UpdateOurHand();
        }
        else
        {
            InitializeOurHand();
        }
    }
    void UpdateOurHand()
    {
        if (ourDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            Debug.Log("Trigger Value =" + triggerValue);
        }
        else
        {
            Debug.Log("TriggerValue not Active");
        }
        if (ourDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            Debug.Log("Grip Value =" + gripValue);
        }
        else
        {
            Debug.Log("Grip not Active");
        }
    }

}
