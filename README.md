```mermaid
graph TB
    %% Definirea straturilor mari (Layers) - Inspirat din structura pe straturi a colegului (Imaginea 3)
    subgraph Layer1 [View Layer (Frontend)]
        direction LR
        V1[Schedule Calendar View<br><i>(Angular/React)</i>]
        V2[Schedule Add Form<br><i>(Form input)</i>]
        V3[Resource Forms<br><i>(Teacher, Room, Group Management)</i>]
    end

    subgraph Layer2 [API/Controller Layer (C# .NET Core MVC)]
        direction LR
        C1[ScheduleController<br><i>(POST/GET/PUT/DELETE schedules)</i>]
        C2[ConflictController<br><i>(CHECK conflicts)</i>]
        C3[ResourceControllers<br><i>(Manage teachers, rooms, groups)</i>]
    end

    subgraph Layer3 [Service Layer (Business Logic) - "Creierul"]
        direction TB
        subgraph SecurityService [SecurityModule]
            direction TB
            Auth[Authentication &<br>Authorization Service]
        end
        
        S1[ScheduleService<br><i>(Core scheduling orchestration)</i>]
        
        subgraph LogicService [BusinessLogicModules]
            direction TB
            S_Conf[<b>ConflictDetectionService</b><br><i>(Rules: overlaps, availability)</i>]
            S_Res[ResourceServices<br><i>(Teacher, Room, Group services)</i>]
        end
    end

    subgraph Layer4 [Repository Layer (Data Access)]
        direction LR
        R1[ScheduleRepository<br><i>(Entity Framework Core)</i>]
        R2[ResourceRepositories<br><i>(Teacher, Room, Group repos)</i>]
    end

    subgraph Layer5 [Data Layer (Persistence)]
        direction LR
        DB[(SQL Server DB)]
        Tables[Schedules,<br>Teachers,<br>Rooms,<br>Groups,<br>Courses]
    end

    %% Relații și Flux de Date - Inspirat din complexitatea interacțiunilor din Imaginea 4
    Actor((User Browser)) -- HTTPS/JSON --> C1
    Actor -- HTTPS/JSON --> C2
    Actor -- HTTPS/JSON --> C3
    
    C1 --> S1
    C2 --> S_Conf
    C3 --> S_Res
    
    %% Interacțiuni interne cruciale
    S1 --> S_Conf : "Verifică conflicte înainte de salvare"
    S1 --> R1 : "Extrage orare existente"
    S_Res --> R2 : "Gestionează datele de resurse"
    
    R1 --> DB : "Citește/Scrie orare"
    R2 --> DB : "Citește/Scrie resurse"
    DB --> Tables : "Persistă datele în tabele"

    %% Stilizare pentru a arăta bine pe GitHub
    classDef layer fill:#f9f9f9,stroke:#333,stroke-width:2px,color:#333;
    classDef component fill:#e1f5fe,stroke:#01579b,stroke-width:1px,color:#01579b;
    classDef critical fill:#ffecb3,stroke:#ff8f00,stroke-width:2px,color:#ff8f00;
    classDef db fill:#e8f5e9,stroke:#1b5e20,stroke-width:1px,color:#1b5e20;

    class Layer1,Layer2,Layer3,Layer4,Layer5 layer;
    class V1,V2,V3,C1,C2,C3,Auth,S1,S_Res,R1,R2 component;
    class S_Conf critical;
    class DB db;```
