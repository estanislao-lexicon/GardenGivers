```mermaid
erDiagram
    Users {
        int UserId PK
        string FirstName // Required StringLength(50)
        string LastName // Required StringLength(50)
        string Email // Required
        string PasswordHash // Required
        string Address
        string City
        string PostNumber        
        datetime DateCreated
    }

    Product {
        int ProductId PK
        string Name // StringLength(50)
        string Description
    }

    Offers {
        int OfferId PK
        int UserId FK
        int ProductId FK
        decimal Quantity // Required
        boolean IsFree // Required
        decimal Price
        datetime DateCreated
        datetime ExpirationDate
    }

    Requests {
        int RequestId PK
        int UserId FK
        int ProductId FK
        decimal Quantity // Required
        datetime DateCreated
    }

    Transactions {
        int TransactionId PK
        int OfferId FK
        int RequestId FK
        decimal Quantity // Required
        datetime TransactionDate
    }
    
    Users ||--o{ Offers : "1-to-many"
    Users ||--o{ Requests : "1-to-many"
    Product ||--o{ Offers : "1-to-many"
    Product ||--o{ Requests : "1-to-many"
    Offers ||--o{ Transactions : "1-to-many"
    Requests ||--o{ Transactions : "1-to-many"

```
