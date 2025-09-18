# Beispiel Kunden_History

```sql
CREATE TABLE Kunden_History (
    HistoryID INT IDENTITY PRIMARY KEY,
    KundeID INT,
    Name NVARCHAR(255),
    Adresse NVARCHAR(255),
    Email NVARCHAR(255),
    Telefonnummer NVARCHAR(50),
    Operation NVARCHAR(10),
    ChangedAt DATETIME2 DEFAULT GETDATE()
);
```

```sql
CREATE TRIGGER trg_Kunden_History
ON Kunden
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- Insert (neue Daten)
    INSERT INTO Kunden_History (KundeID, Name, Adresse, Email, Telefonnummer, Operation, ChangedAt)
    SELECT i.KundeID, i.Name, i.Adresse, i.Email, i.Telefonnummer, 'INSERT', GETDATE()
    FROM inserted i;

    -- Update (alte Daten sichern)
    INSERT INTO Kunden_History (KundeID, Name, Adresse, Email, Telefonnummer, Operation, ChangedAt)
    SELECT d.KundeID, d.Name, d.Adresse, d.Email, d.Telefonnummer, 'UPDATE', GETDATE()
    FROM deleted d;

    -- Delete (alte Daten löschen)
    INSERT INTO Kunden_History (KundeID, Name, Adresse, Email, Telefonnummer, Operation, ChangedAt)
    SELECT d.KundeID, d.Name, d.Adresse, d.Email, d.Telefonnummer, 'DELETE', GETDATE()
    FROM deleted d;
END;
```
