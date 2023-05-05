public interface IObjectSetting
{
    enum ObjectTag
    {
        None = 0,
        Entity = 1,
        Foe = 2,
        Player = 3,
        LevelEdges = 4,
    }

    public ObjectTag EObjectTag { get; }
}