using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ColorChanger : MonoBehaviour
{
    public Material selectMaterial = null;

    private MeshRenderer meshRenderer = null;
    private XRBaseInteractable interactable = null;
    private Material originalMaterial = null;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        originalMaterial = meshRenderer.material;

        interactable = GetComponent<XRBaseInteractable>();
        interactable.onHoverEnter.AddListener(SetSelectMaterial);
        interactable.onHoverExit.AddListener(SetOriginalMaterial);
    }

    private void OnDestroy()
    {
        interactable.onHoverEnter.RemoveListener(SetSelectMaterial);
        interactable.onHoverExit.RemoveListener(SetOriginalMaterial);
    }

    private void SetSelectMaterial(XRBaseInteractor interactor)
    {
        meshRenderer.material = selectMaterial;
    }

    private void SetOriginalMaterial(XRBaseInteractor interactor)
    {
        meshRenderer.material = originalMaterial;
    }
}
