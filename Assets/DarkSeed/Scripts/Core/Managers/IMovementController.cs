namespace DarkSeed.Core.Managers
{
    public interface IMovementController
    {
        public bool IsMovementEnabled { get;}

        public void EnableMovementRequest();
        public void DisableMovementRequest();
    }
}