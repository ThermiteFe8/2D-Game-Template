using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaChecker : MonoBehaviour
{
    //Attach this to a GameObject with a 2D collider component
    //Activates the different bools based on whether it just entered the collider, whether it's still in the collider, or whether it just left the collider
    //Mostly used for a cleaner GroundCheck than I used to have, but you could also use it for wallchecks and other stuff
    //The LayerMask layer's also helpful if you want this to only work with stuff on the Ground layer or just on the enemy layer

    public bool isTouching;
    public bool justTouched;
    public bool justLeft;
    public LayerMask layer;
    

    private bool wasTouching; // Track the previous frame's touching state

    private void Update()
    {
        // Update justTouched and justLeft based on the current and previous touching states
        justTouched = isTouching && !wasTouching;
        justLeft = !isTouching && wasTouching;

        // Update the previous touching state for the next frame
        wasTouching = isTouching;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (IsLayerIncluded(layer, collision.gameObject.layer))
        {
            isTouching = true;
        }
        else
        {
            isTouching = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsLayerIncluded(layer, collision.gameObject.layer))
        {
            isTouching = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (IsLayerIncluded(layer, collision.gameObject.layer))
        {
            isTouching = false;
        }
    }

    // Function to check if a layer is included in a LayerMask
    bool IsLayerIncluded(LayerMask layerMask, int layer)
    {
        int layerMaskBit = 1 << layer;
        return (layerMask.value & layerMaskBit) > 0;
    }
}