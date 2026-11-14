
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class UIRaycastDebugger : MonoBehaviour
{
    void Update()
    {
        if (Mouse.current == null)
            return;

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            if (EventSystem.current == null)
            {
                Debug.LogError("EventSystem is missing!");
                return;
            }

            PointerEventData pointerData =
                new PointerEventData(EventSystem.current);

            pointerData.position =
                Mouse.current.position.ReadValue();

            List<RaycastResult> results =
                new List<RaycastResult>();

            EventSystem.current.RaycastAll(pointerData, results);

            if (results.Count == 0)
            {
                Debug.Log("NO UI ELEMENT DETECTED");
            }

            foreach (RaycastResult result in results)
            {
                Debug.Log("UI HIT: " + result.gameObject.name);
            }
        }
    }
}
