using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickButtonWithRaycast : MonoBehaviour
{
    Button button; //当前打到的button
    PointerEventData data;
    private void Start()
    {
        data = new UnityEngine.EventSystems.PointerEventData(EventSystem.current) { button = UnityEngine.EventSystems.PointerEventData.InputButton.Left };
    }
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, 1000f))
        {

            var  temp = hit.transform.GetComponent<Button>(); //当前打到的
            if (!button)
            {
                button = temp;
                button.OnPointerEnter(null);
            }
            else
            {
                if (button==temp)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        button.OnPointerDown(data);
                    }
                    if (Input.GetMouseButtonUp(0))
                    {
                        button.OnSubmit(null);
                        button.OnPointerUp(data);
                    }
                }
                else
                {
                    button.OnPointerExit(data);
                    button = temp;
                    button.OnPointerEnter(data);
                }
            }
        }
        else
        {
            if (button)
            {
                button.OnPointerExit(null);
                button = null;
            }
        }

    }
}
