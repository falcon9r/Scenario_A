namespace Scenario_A.Migrations
{
    public class _23_01_2024_Migration : IMigration
    {
        public string Down()
        {
            return @"
                SET FOREIGN_KEY_CHECKS=0;
                DROP TABLE IF EXISTS ERNAHRUNGSKATEGORIEZUTAT;
                DROP TABLE IF EXISTS BESCHRAKUNGZUTAT;

                DROP TABLE IF EXISTS BESCHRAKUNG;
                DROP TABLE IF EXISTS ERNAHRUNGSKATEGORIE;
                SET FOREIGN_KEY_CHECKS=1;
                ";
        }

        public string Up()
        {
            return @"
                CREATE TABLE BESCHRAKUNG (
                    BESCHRAKUNGID INTEGER NOT NULL,
                    NAME VARCHAR(255),
                    PRIMARY KEY (BESCHRAKUNGID)
                );

                CREATE TABLE ERNAHRUNGSKATEGORIE (
                    ERNAHRUNGSKATEGORIEID INTEGER NOT NULL,
                    NAME VARCHAR(255),
                    PRIMARY KEY (ERNAHRUNGSKATEGORIEID)
                );

                CREATE TABLE ERNAHRUNGSKATEGORIEZUTAT (
                    ZUTATENNR       INTEGER,
                    ERNAHRUNGSKATEGORIEID  INTEGER,
                    PRIMARY KEY (ZUTATENNR,ERNAHRUNGSKATEGORIEID),
                    FOREIGN KEY (ZUTATENNR) REFERENCES ZUTAT (ZUTATENNR),
                    FOREIGN KEY (ERNAHRUNGSKATEGORIEID) REFERENCES ERNAHRUNGSKATEGORIE (ERNAHRUNGSKATEGORIEID)
                );
                
                CREATE TABLE BESCHRAKUNGZUTAT (
                    ZUTATENNR       INTEGER,
                    BESCHRAKUNGID  INTEGER,
                    PRIMARY KEY (ZUTATENNR,BESCHRAKUNGID),
                    FOREIGN KEY (ZUTATENNR) REFERENCES ZUTAT (ZUTATENNR),
                    FOREIGN KEY (BESCHRAKUNGID) REFERENCES BESCHRAKUNG (BESCHRAKUNGID)
                );
            ";
        }
    }
}
