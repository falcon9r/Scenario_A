namespace Scenario_A.Migrations
{
    public interface IMigration
    {
        public string Up();

        public string Down();
    }
}
