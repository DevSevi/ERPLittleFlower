# Arbeitsdokumentation

In dieser Arbeit geht es darum, ein ERP-System aufzubauen, inkl. ERM-Modellierung, Aufbau Datenbank in SQL-Server und Umsetzung mit Testfällen. Allenfalls werde ich gegen Schluss auch noch ein einfaches GUI dazu programmieren. Der Fokus liegt jedoch klar auf dem Aufbau der Datenbank.

## Ablauf

Ein erster Entwurf des Ablaufs der Arbeit sieht folgendermassen aus:

1. ERM
   1.1 Leistungsflussdiagramm
   1.2 Korrelationsmatrix
   1.3 Modell
2. Projektmanagement
   2.1 Situationsanalyse
   2.2 Zielsetzungen (Stakeholder und funktional)
   2.3 Lösungssuche und -bewertung (eingeschränkt)
   2.4 Planung und Controlling (Earned Value Analyse)
3. Umsetzung in SQL-Server
   3.1 Datenbank und Tabellen inkl. Pkeys und Fkeys
   3.2 Triggers?
4. Umsetzung in Konsolen-App
   4.1 Verbindung zu DB wie?
5. GUI
   5.1 evtl. mit Blazor?

## ERM

### Leistungsflussdiagramm

Um überhaupt zu wissen, welche Entitäten benötigt werden stelle ich zuerst das Leistungsflussdiagramm auf.

```mermaid
flowchart TD
    %% Bereiche
    subgraph Kunde
        K1[Kunde bestellt Artikel]
    end

    subgraph Finanzen
        F1[Debitor prüfen/anlegen]
        F2[Rechnung erstellen]
        F3[Zahlung verbuchen]
    end

    subgraph Lager
        L1[Bestand prüfen]
        L2[Lagerort ermitteln]
        L3[Artikel aus Lager ausbuchen]
        L4[Bestand aktualisieren]
    end

    subgraph Einkauf
        E1[Unterbestand festgestellt]
        E2[Lieferant auswählen]
        E3[Bestellung erfassen]
        E4[Wareneingang verbuchen]
        E5[Bestand ergänzen]
    end

    %% Prozessfluss
    K1 --> F1 --> F2
    F2 --> L1
    L1 -->|Bestand vorhanden| L2 --> L3 --> L4 --> F3
    L1 -->|Bestand zu niedrig| E1 --> E2 --> E3 --> E4 --> E5 --> L4
```

### Modell

[ERM](ERM.md)
