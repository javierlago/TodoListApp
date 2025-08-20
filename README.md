# TodoListApp

A simple **ToDo List application** built with **Blazor Server** on **.NET 8**.  
This project is a learning exercise to understand Blazor components, dependency injection (DI), and basic state management in C#.

---

## ✨ Features (current & planned)
- In-memory task storage via a `TodoService` (current).
- List tasks ordered by creation date (UI wiring in progress).
- Add new tasks (service implemented; UI coming next).
- Mark tasks as completed, edit, and delete (planned).
- Optional persistence with EF Core (planned).

---

## 🛠️ Tech Stack
- [.NET 8 SDK](https://dotnet.microsoft.com/)
- [Blazor Server](https://learn.microsoft.com/aspnet/core/blazor)
- C# 12
- Built-in Dependency Injection

---

## 📂 Project Structure
```
TodoListApp/
│
├── Models/
│   └── TodoItem.cs          # Represents a single task
│
├── Services/
│   ├── ITodoService.cs      # Service interface (contract)
│   └── TodoService.cs       # In-memory implementation
│
├── Pages/
│   ├── Todos.razor          # UI for displaying tasks
│   └── Todos.razor.cs       # Code-behind with page logic
│
├── Shared/
│   └── NavMenu.razor        # Navigation links (Home, ToDos)
│
└── Program.cs               # App configuration & DI setup
```

---

## 🚀 Getting Started

### Prerequisites
- Install the **.NET 8 SDK**.

### Run the project
```bash
dotnet run --project TodoListApp
```

Open the app and navigate to `/todos` (e.g., http://localhost:5000/todos or https://localhost:5001/todos).

---

## 🔧 How It Works (high level)
- `Program.cs` registers services and configures Blazor Server (SignalR circuit, routing).
- `ITodoService` defines the contract for task operations.
- `TodoService` provides an **in-memory**, thread-safe store using `ConcurrentDictionary`.
- `Todos.razor` + `Todos.razor.cs` render and manage the ToDo page.
- The app is intentionally minimal to focus on Blazor fundamentals before adding persistence.

---

## 📝 Roadmap
- Wire up UI for listing and adding tasks.
- Toggle completion, edit titles, and delete tasks.
- Persist data with EF Core (SQLite/SQL Server).
- Add filtering and basic validation.

---

## 📖 Learning Goals
- Create and structure a Blazor Server project from scratch.
- Clean the default template and add a custom page.
- Register and consume services via DI.
- Manage component state and lifecycle (`OnInitializedAsync`).

---

## 📜 License
This project is for learning purposes. Feel free to fork, modify, and experiment.

