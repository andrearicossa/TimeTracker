# 🕒 Time Tracker

> **Un'applicazione desktop moderna per il tracciamento delle attività giornaliere, creata interamente con l'intelligenza artificiale.**

[![.NET](https://img.shields.io/badge/.NET-9.0-purple.svg)](https://dotnet.microsoft.com/)
[![WPF](https://img.shields.io/badge/WPF-Windows-blue.svg)](https://docs.microsoft.com/en-us/dotnet/desktop/wpf/)
[![License](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)
[![AI Generated](https://img.shields.io/badge/AI%20Generated-100%25-orange.svg)](https://github.com/features/copilot)

## 📖 Descrizione

Time Tracker è un'applicazione desktop WPF moderna progettata per aiutare professionisti, studenti e chiunque voglia ottimizzare la gestione del tempo. L'app combina semplicità d'uso con funzionalità avanzate per il tracciamento preciso delle attività quotidiane.

### 🎯 A cosa serve

- **Tracciamento temporale preciso**: Monitora esattamente quanto tempo dedichi a ogni attività
- **Gestione progetti**: Organizza le tue attività per progetti o categorie
- **Analisi produttività**: Visualizza dove impieghi il tuo tempo
- **Time blocking**: Pianifica sessioni di lavoro con timer personalizzabili
- **Reportistica**: Storico completo delle attività con date e durate
- **Workflow Pomodoro**: Supporto nativo per tecniche di produttività

## ✨ Caratteristiche Principali

### 🔧 **Gestione Attività**
- ➕ **Creazione rapida**: Aggiungi nuove attività con nome e durata personalizzata
- ✏️ **Modifica completa**: Modifica nome, durata, date di inizio e fine
- 🗑️ **Eliminazione sicura**: Rimuovi attività con conferma per evitare errori
- 💾 **Salvataggio automatico**: I dati vengono salvati automaticamente in formato JSON

### ⏱️ **Timer Integrato**
- ▶️ **Cronometro preciso**: Timer con aggiornamento in tempo reale
- 🎯 **Durata personalizzabile**: Imposta qualsiasi durata (default 25 minuti)
- 🔔 **Notifiche**: Avviso automatico al completamento
- ⏹️ **Stop manuale**: Possibilità di fermare il timer in anticipo
- 📊 **Tracciamento automatico**: Date e orari registrati automaticamente

### 🎨 **Interfaccia Moderna**
- 🖱️ **Pulsanti con icone**: Interfaccia intuitiva con simboli universali
- 🌈 **Codifica colori**: Verde per azioni positive, blu per modifiche, rosso per eliminazioni
- 📱 **Design responsive**: Pulsanti che si espandono al passaggio del mouse
- 🪟 **Finestre multiple**: Interfacce specializzate per ogni funzione
- 🏷️ **Tooltips informativi**: Descrizioni dettagliate per ogni azione

### 💼 **Funzionalità Professionali**
- 📅 **Gestione date/orari**: Controllo completo su tempi di inizio e fine
- 🔄 **Validazione dati**: Controlli automatici per evitare errori di inserimento
- 📋 **Griglia dati**: Visualizzazione tabellare con tutte le informazioni
- 🎯 **Versioning**: Sistema di versioni integrato
- 🔒 **Persistenza dati**: Salvataggio affidabile in formato JSON

## 🤖 Creazione con Intelligenza Artificiale

**Questa applicazione è stata progettata e sviluppata al 100% utilizzando l'intelligenza artificiale**, nello specifico GitHub Copilot e Claude. Il processo di sviluppo ha dimostrato le capacità avanzate dell'AI nel:

- 🧠 **Analisi dei requisiti**: Comprensione e traduzione delle specifiche in codice funzionale
- 🏗️ **Architettura software**: Progettazione di una struttura modulare e manutenibile
- 🎨 **Design UX/UI**: Creazione di interfacce intuitive e moderne
- 🔧 **Problem solving**: Risoluzione di problemi tecnici complessi
- 📚 **Best practices**: Applicazione di pattern e convenzioni .NET/WPF
- 🐛 **Debug e testing**: Identificazione e correzione di bug
- 📖 **Documentazione**: Creazione di documentazione completa

### 🛠️ Stack Tecnologico (AI-Generated)
- **Framework**: .NET 9.0 Windows Desktop
- **UI Framework**: WPF (Windows Presentation Foundation)
- **Linguaggio**: C# con nullable reference types
- **Persistenza**: JSON file-based storage
- **Pattern**: MVVM-inspired architecture
- **Icone**: Unicode vector graphics
- **Build**: MSBuild con configurazioni Release/Debug

## 🚀 Installazione e Utilizzo

### 📋 Requisiti di Sistema
- Windows 10/11 (64-bit)
- .NET 9.0 Runtime (Windows Desktop)
- 50 MB di spazio libero

### 💿 Installazione

#### Opzione 1: Eseguibile Precompilato
1. Scarica `TimeTracker-v1.0.0-Release.zip`
2. Estrai tutti i file in una cartella
3. Esegui `TimeTracker.exe`

#### Opzione 2: Compilazione da Sorgenti
```bash
git clone https://github.com/andrearicossa/TimeTracker.git
cd TimeTracker
dotnet build --configuration Release
dotnet run
```

### 📖 Guida Rapida

1. **➕ Crea una nuova attività**
   - Clicca il pulsante "➕ Nuovo"
   - Inserisci nome e durata (default: 25 minuti)
   - Clicca "Salva"

2. **▶️ Avvia il timer**
   - Clicca l'icona "▶" nella riga dell'attività
   - Il timer inizia automaticamente
   - La finestra principale si nasconde per non disturbare

3. **✏️ Modifica attività**
   - Clicca l'icona "✎" per modificare
   - Cambia nome, durata, date di inizio/fine
   - Lascia campi vuoti per attività non ancora temporizzate

4. **🗑️ Elimina attività**
   - Clicca l'icona "✖" (rossa)
   - Conferma l'eliminazione
   - L'attività viene rimossa permanentemente

## 📁 Struttura del Progetto

```
TimeTracker/
├── 📄 MainWindow.xaml/cs          # Finestra principale con griglia attività
├── 📄 NewActivityWindow.xaml/cs   # Dialog per creare nuove attività  
├── 📄 EditActivityWindow.xaml/cs  # Dialog per modificare attività esistenti
├── 📄 TimerWindow.xaml/cs         # Finestra del cronometro
├── 📄 Activity.cs                 # Modello dati per le attività
├── 📄 ActivityManager.cs          # Gestione persistenza JSON
├── 📄 activities.json             # File dati (generato automaticamente)
└── 📄 TimeTracker.csproj          # Configurazione progetto .NET
```

## 📊 Dati e Privacy

- **💾 Salvataggio locale**: Tutti i dati rimangono sul tuo computer
- **🔒 Privacy garantita**: Nessun dato viene inviato online
- **📂 File JSON**: Formato leggibile e facilmente esportabile
- **🔄 Backup manuale**: Copia `activities.json` per backup
- **📈 Portabilità**: Dati facilmente importabili in altri strumenti

## 🤝 Contribuire

Questo progetto dimostra le potenzialità dell'AI nel development software. Contributi e feedback sono benvenuti:

1. 🍴 Fork del repository
2. 🌟 Crea un feature branch
3. 💻 Implementa le modifiche
4. 📤 Apri una Pull Request

## 📝 Licenza

Distribuito sotto licenza MIT. Vedi `LICENSE` per maggiori informazioni.

## 🙏 Riconoscimenti

- **🤖 GitHub Copilot**: Per l'assistenza alla programmazione
- **🧠 Claude AI**: Per il design e l'architettura
- **🏢 Microsoft**: Per .NET e WPF Framework
- **👨‍💻 Sviluppatore**: Andrea Ricossa (Human supervisor)

---

**Time Tracker v1.0.0** - Un esempio di sviluppo software guidato dall'intelligenza artificiale.

*Creato nel 2025 come dimostrazione delle capacità creative e tecniche dell'AI moderna.*