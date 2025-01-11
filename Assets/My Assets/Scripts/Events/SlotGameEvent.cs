using UnityEngine;

namespace GD.Events
{
    /// <summary>
    /// Concrete implementation of BaseGameEvent that carries an int parameter.
    /// Used to create an integer-based event that can be raised and responded to.
    /// </summary>
    [CreateAssetMenu(fileName = "SlotGameEvent",
        menuName = "GD/Events/Params/Slot",
        order = 4)]
    public class SlotGameEvent : BaseGameEvent<Slot>
    { }
}