using UnityEngine;

public class EegManager : MonoBehaviour
{
    public Material flashMaterial;
    public Material darkMaterial;

    public bool fakeFlashing;
    public double fakeFlashingSpeed = 1.0;

    private const int MaxVisibleSurfaces = 6;
    private readonly int[] eegGroupMembers = new int[MaxVisibleSurfaces];
    private readonly bool[] eegGroupsFlash = new bool[MaxVisibleSurfaces];

    // Start is called before the first frame update
    private void Start()
    {
        for (var i = 0; i < MaxVisibleSurfaces; i++)
        {
            eegGroupMembers[i] = 0;
            eegGroupsFlash[i] = false;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (!fakeFlashing) return;
        for (var i = 0; i < MaxVisibleSurfaces; i++)
            if (Random.Range(0f, 1f) < 0.03 * fakeFlashingSpeed)
            {
                eegGroupsFlash[i] = !eegGroupsFlash[i];
            }
    }

    public int AssignFlashingGroup()
    {
        var smallestGroup = 0;
        for (var i = 1; i < MaxVisibleSurfaces; i++)
            if (eegGroupMembers[i] < eegGroupMembers[smallestGroup])
                smallestGroup = i;
        if (eegGroupMembers[smallestGroup] > 0)
        {
            Debug.LogWarning($"Too many EEG surfaces (> {MaxVisibleSurfaces}) on screen at once");
        }
        eegGroupMembers[smallestGroup]++;
        return smallestGroup;
    }

    public void UnAssignFlashingGroup(int group)
    {
        if (eegGroupMembers[group] > 0) eegGroupMembers[group]--;
    }

    public Material GroupMaterial(int group)
    {
        return eegGroupsFlash[group] ? flashMaterial : darkMaterial;
    }
}
