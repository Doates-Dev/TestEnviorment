using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;

    private Transform _selection;

    private void Update()
    {
        // Reset previous selection
        if (_selection != null)
        {
            Renderer previousRenderer = _selection.GetComponent<Renderer>();

            if (previousRenderer != null)
            {
                previousRenderer.material = defaultMaterial;
            }

            _selection = null;
        }

        // Ray from the exact center of the camera
        Ray ray = Camera.main.ViewportPointToRay(
            new Vector3(0.5f, 0.5f, 0f)
        );

        // Unlimited range
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
        {
            Transform selection = hit.transform;

            if (selection.CompareTag(selectableTag))
            {
                Breakable breakable = selection.GetComponent<Breakable>();
                if (breakable != null && !breakable.IsBroken)
                {
                    breakable.BreakFromSelection();
                    return; // object is being destroyed this frame, nothing left to highlight
                }

                Renderer selectionRenderer = selection.GetComponent<Renderer>();

                if (selectionRenderer != null)
                {
                    selectionRenderer.material = highlightMaterial;
                    _selection = selection;
                }
            }
        }
    }
}