```mermaid
erDiagram
    Users {
        int UserId PK
        string FirstName // StringLength(50)
        string LastName
        string Email // Required
        string PasswordHash // Required
        string Address
        string City
        string PostNumber        
        datetime DateCreated
    }

    Produce {
        int ProduceId PK
        string Name // StringLength(50)
        string Description
    }

    Offers {
        int OfferId PK
        int UserId FK
        int ProduceId FK
        decimal Quantity
        boolean IsFree
        decimal Price
        datetime DateCreated
        datetime ExpirationDate
    }

    Requests {
        int RequestId PK
        int UserId FK
        int ProduceId FK
        decimal Quantity
        datetime DateCreated
    }

    Transactions {
        int TransactionId PK
        int OfferId FK
        int RequestId FK
        decimal Quantity
        datetime TransactionDate
    }
    
    Users ||--o{ Offers : "1-to-many"
    Users ||--o{ Requests : "1-to-many"
    Produce ||--o{ Offers : "1-to-many"
    Produce ||--o{ Requests : "1-to-many"
    Offers ||--o{ Transactions : "1-to-many"
    Requests ||--o{ Transactions : "1-to-many"

```
