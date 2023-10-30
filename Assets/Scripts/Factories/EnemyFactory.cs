public class EnemyFactory : AbstractFactory<IPoolable>
{
    public EnemyFactory(IPoolable objectToCreate) : base(objectToCreate)
    {
    }

    public override IPoolable CreateObject()
    {
        throw new System.NotImplementedException();
    }
}