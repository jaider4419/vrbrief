using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Hammer : MonoBehaviour
{
    public UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable grabInteractable;

    private void Start()
    {
        grabInteractable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mole"))
        {
            MoleJump mole = other.GetComponent<MoleJump>();
            if (mole != null)
            {
                mole.OnHit();
                HapticFeedback();
            }
        }
    }

    private void HapticFeedback()
    {
        if (grabInteractable.isSelected)
        {
            UnityEngine.XR.Interaction.Toolkit.Interactors.XRBaseInputInteractor interactor = grabInteractable.interactorsSelecting[0] as UnityEngine.XR.Interaction.Toolkit.Interactors.XRBaseInputInteractor;
            if (interactor != null)
            {
                interactor.SendHapticImpulse(0.5f, 0.2f);
            }
        }
    }
}
