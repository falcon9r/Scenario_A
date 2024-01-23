using Scenario_A.Migrations;
using System.Collections.Generic;

namespace Scenario_A.Database
{
    public class Setup
    {
        private readonly Database _database;
        public Setup(Database database) 
        {
            _database = database;
        }

        public void MigrateDatabase() 
        {
            List<IMigration> migrations = this.GetMigrations();
            
            foreach (IMigration migration in migrations)
            {
                Console.WriteLine(migration.Up());
                _database.ExecuteNonQuery(migration.Up());   
            }

            Console.WriteLine("The migrations was successful...");
        }

        public void ResetDatabase()
        {
            List<IMigration> migrations = this.GetMigrations();

            foreach (IMigration migration in migrations)
            {
                Console.WriteLine(migration.Down());
                _database.ExecuteNonQuery(migration.Down());
            }

            Console.WriteLine("The migrations was successful...");
        }
        private List<IMigration> GetMigrations()
        {
            List<IMigration> migrations = new List<IMigration>();
            
            List<Type> implementingClasses = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.GetInterface(nameof(IMigration)) != null && !type.IsInterface)
                .ToList();

            foreach (Type type in implementingClasses)
            {
                IMigration migration = (IMigration)Activator.CreateInstance(type);
                if(migration is not null)
                {
                    migrations.Add(migration);
                }
            }

            return migrations;
        }
    }
}
