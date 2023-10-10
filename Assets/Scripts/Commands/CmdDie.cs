public class CmdDie : IReversibleCommand
{
    private readonly IDamageable _victim;

    public CmdDie(IDamageable victim)
    {
        _victim = victim;
    }
    
    public void Execute()
    {
        _victim.Die();
    }

    public void Reverse()
    {
        _victim.Revive();
    }
}