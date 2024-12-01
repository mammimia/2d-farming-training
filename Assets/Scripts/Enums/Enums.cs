public enum ToolEffect
{
    none,
    watering
}

public enum MovementState
{
    Walking,
    Running,
    Idle,
    Carrying,
    UsingTool
}

public enum ToolAction
{
    None,
    Using,
    Lifting,
    Picking,
    Swinging
}

public enum Direction
{
    None,
    Right,
    Left,
    Up,
    Down
}

public enum ItemType
{
    None,
    Seed,
    Crop,
    Tool,
    Consumable,
    Furniture,
    Resource,
    Reapable,
}

public enum ToolType
{
    None,
    Watering,
    Hoeing,
    Chopping,
    Breaking,
    Reaping,
    Sickle,
    Collecting
}

public enum Season
{
    None,
    Spring,
    Summer,
    Autumn,
    Winter
}

public enum DayOfTheWeek
{
    None,
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday
}

public enum MonthName
{
    None,
    Jan,
    Feb,
    Mar,
    Apr,
    May,
    Jun,
    Jul,
    Aug,
    Sep,
    Oct,
    Nov,
    Dec
}

public enum SceneName
{
    Scene1_Farm,
    Scene2_Field,
    Scene3_Cabin,
}