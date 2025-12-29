using UnityEngine;

public class Apple : Pickup
{
    [SerializeField] float adjustChangemoveSpeed = 3f;
    LevelGenerator levelGenerator;
    public void Init(LevelGenerator levelGenerator)
    {
        this.levelGenerator = levelGenerator;// fast way to assign levelgenerator reference
    }
    protected override void OnPickup()
    {
        levelGenerator.ChangeChunkMoveSpeed(adjustChangemoveSpeed);
    }
}
