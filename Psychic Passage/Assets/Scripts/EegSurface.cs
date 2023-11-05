using UnityEngine;

public class EegSurface : MonoBehaviour
{
    private Renderer myRenderer;

    private EegManager eegManager;
    // 0 means not flashing
    private int flashingGroup;

    // Start is called before the first frame update
    private void Start()
    {
        myRenderer = GetComponent<Renderer>();
        eegManager = FindObjectOfType<EegManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        switch (myRenderer.isVisible)
        {
            case true when flashingGroup == 0:
                flashingGroup = eegManager.AssignFlashingGroup();
                break;
            case false when flashingGroup != 0:
                eegManager.UnAssignFlashingGroup(flashingGroup);
                flashingGroup = 0;
                break;
        }

        myRenderer.material = eegManager.GroupMaterial(flashingGroup);
    }
}
