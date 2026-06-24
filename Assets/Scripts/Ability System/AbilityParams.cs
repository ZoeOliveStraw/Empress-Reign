using UnityEngine;

namespace Ability_System
{
    public struct AbilityParams
    {
        //AN ACTOR OTHER THAN THE ABILITY OWNER THAT WILL BE AFFECTED BY THE ABILITY
        public Actor TargetActor;
        //A 3D VECTOR THAT CAN BE USED FOR ARGUMENTS
        public Vector3 Axis3D;
        //A 2d VECTOR THAT CAN BE USED FOR ARGUMENTS 
        public Vector2 Axis2D;

        public AbilityParams(
            Actor myActor = null,
            Actor targetActor = null,
            Vector3 axis3D = default,
            Vector2 axis2D = default)

        {
            TargetActor = targetActor;
            Axis3D = axis3D;
            Axis2D = axis2D;
        }
    }
}