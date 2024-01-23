namespace Scenario_A.Migrations
{
    public class _22_01_2024_Migration : IMigration
    {
        public string Down()
        {
            return @"
                SET FOREIGN_KEY_CHECKS=0;
                DROP TABLE IF EXISTS BESTELLUNGZUTAT;
                DROP TABLE IF EXISTS BESTELLUNG;
                DROP TABLE IF EXISTS ZUTAT;
                DROP TABLE IF EXISTS LIEFERANT;
                DROP TABLE IF EXISTS KUNDE;
                SET FOREIGN_KEY_CHECKS=1;
            ";
        }

        public string Up()
        {
            return @"
                CREATE TABLE KUNDE (
                    KUNDENNR        INTEGER NOT NULL,
                    NACHNAME        VARCHAR(50),
                    VORNAME         VARCHAR(50),
                    GEBURTSDATUM	DATE,
	                STRASSE         VARCHAR(50),
	                HAUSNR			VARCHAR(6),			
                    PLZ             VARCHAR(5),
                    ORT             VARCHAR(50),
                    TELEFON         VARCHAR(25),
                    EMAIL           VARCHAR(50),
                    PRIMARY KEY (KUNDENNR)
                );

                CREATE TABLE LIEFERANT (
                    LIEFERANTENNR   INTEGER NOT NULL,
                    LIEFERANTENNAME VARCHAR(50),
                    STRASSE         VARCHAR(50),
                    HAUSNR			VARCHAR(6),
                    PLZ             VARCHAR(5),
                    ORT             VARCHAR(50),
                    TELEFON			VARCHAR(25),
                    EMAIL           VARCHAR(50),
                    PRIMARY KEY (LIEFERANTENNR)
                );

                CREATE TABLE ZUTAT(
                    ZUTATENNR			INTEGER NOT NULL,
                    BEZEICHNUNG         VARCHAR(50),
                    EINHEIT        		VARCHAR (25),
                    NETTOPREIS       	DECIMAL(10,2),
                    BESTAND             INTEGER,
                    LIEFERANT			INTEGER,
	                KALORIEN			INTEGER,
	                KOHLENHYDRATE		DECIMAL (10,2),
	                PROTEIN			    DECIMAL(10,2),
	                PRIMARY KEY (ZUTATENNR),
	                FOREIGN KEY (LIEFERANT) REFERENCES LIEFERANT (LIEFERANTENNR)
                );

                CREATE TABLE BESTELLUNG (
                    BESTELLNR        INTEGER AUTO_INCREMENT NOT NULL,
                    KUNDENNR         INTEGER,
                    BESTELLDATUM     DATE,
                    RECHNUNGSBETRAG  DECIMAL(10,2),
                    PRIMARY KEY (BESTELLNR),
                    FOREIGN KEY (KUNDENNR) REFERENCES KUNDE (KUNDENNR)
                );

                CREATE TABLE BESTELLUNGZUTAT (
                    BESTELLNR       INTEGER NOT NULL,
                    ZUTATENNR       INTEGER,
                    MENGE     		INTEGER,
                    PRIMARY KEY (BESTELLNR,ZUTATENNR),
                    FOREIGN KEY (BESTELLNR) REFERENCES BESTELLUNG (BESTELLNR),
                    FOREIGN KEY (ZUTATENNR) REFERENCES ZUTAT (ZUTATENNR)
                );
            ";

        }
    }
}
